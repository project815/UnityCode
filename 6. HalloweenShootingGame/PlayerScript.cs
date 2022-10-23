using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;
using Cinemachine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    PlayerInput playerInput;
    public ParticleSystem walkParticle;
    public ParticleSystem jumoParticle;

    private JoyStickInputManager joystick;
    private float haxis;
    private float vaxis;


    public Rigidbody2D rigid;
    public CapsuleCollider2D col; 
    public Animator animator;

    public SpriteRenderer spriteRenderer;
    public PhotonView photonview;
    public TMP_Text text_nickName;

    public Slider slider_Health;
    public LayerMask layerMask;

    public AudioSource audioSource;
    public AudioClip clip_Attack;
    public AudioClip clip_Walk;
    public AudioClip clip_Jump;
    public AudioClip clip_GameLose;

    bool isGround;
    Vector3 curPos;

    private float speed = 8f;
    private bool isClimbing;
    private bool isCrouch;

    private GameObject currentTeleporter;

    void Start()
    {
        text_nickName.text = photonview.IsMine ? PhotonNetwork.NickName : photonview.Owner.NickName;
        text_nickName.color = photonview.IsMine ? Color.green : Color.red;

        if(photonview.IsMine)
        {
            var CM = GameObject.Find("CMvcam").GetComponent<CinemachineVirtualCamera>();
            CM.Follow = transform;
            CM.LookAt = transform;

            joystick = FindObjectOfType<JoyStickInputManager>();
        }
        playerInput = GetComponent<PlayerInput>();
        
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Teleporter"))
        {
            currentTeleporter = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {

        if(other.CompareTag("Teleporter"))
        {
            if(other.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(photonview.IsMine)
        {
            Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        
            Debug.Log(input);
            //이동 <- ->
            haxis = input.x;
            vaxis = input.y;
            if(!isCrouch)
            rigid.velocity = new Vector2(4* haxis, rigid.velocity.y);
            else
            rigid.velocity = Vector2.zero;

            if(haxis != 0)
            {
                animator.SetFloat("hAxis", haxis);
                animator.SetBool("Run", true);
                photonView.RPC("FlipXRPC", RpcTarget.AllBuffered, haxis); //재접속시 filpx를 동기화해주기 위해서 All Buffered
                if(isGround)
                {
                    walkParticle.Play();

                    if(!audioSource.isPlaying)
                    audioSource.PlayOneShot(clip_Walk);
                }
            }
            else
            {
                animator.SetFloat("hAxis", haxis);
                animator.SetBool("Run", false);
            }


            //점프, 바닥체크
            int index = 1 << LayerMask.NameToLayer("Ground");
            isGround = Physics2D.OverlapCircle((Vector2)transform.position + new Vector2(0, -0.5f), 1.2f, 1 << LayerMask.NameToLayer("Ground"));
            animator.SetBool("Jump", !isGround);
           
            if(CrossPlatformInputManager.GetButtonDown("Jump") && isGround)
            {
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * 700f);
                audioSource.PlayOneShot(clip_Jump);
                jumoParticle.Play();
            } 

            //웅크리기
            isCrouch = CrossPlatformInputManager.GetButton("Crouch");  
            animator.SetBool("Crouch", isCrouch);
            photonview.RPC("CrouchRPC", RpcTarget.AllBuffered, isCrouch);

            //공격
            if(CrossPlatformInputManager.GetButtonDown("Attack"))
            {
                PhotonNetwork.Instantiate("Bullet", transform.position + new Vector3(spriteRenderer.flipX ? -0.4f : 0.4f, 0.5f, 0), Quaternion.identity)
                    .GetComponent<PhotonView>().RPC("DirRPC", RpcTarget.AllBuffered, spriteRenderer.flipX ? -1 : 1);
                photonview.RPC("AttackRPC", RpcTarget.All);
                audioSource.PlayOneShot(clip_Attack);
            }

            //텔레포트
            if(CrossPlatformInputManager.GetButtonDown("Teleport") && currentTeleporter != null)
            {
                animator.SetTrigger("Teleport");
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }

        }
        else if ((transform.position - curPos).sqrMagnitude >= 100) transform.position = curPos;
        else transform.position = Vector3.Lerp(transform.position, curPos, Time.deltaTime * 10);
    }

    [PunRPC]
    void FlipXRPC(float axis) => spriteRenderer.flipX = axis < 0;
    [PunRPC]
    void AttackRPC() => animator.SetTrigger("Attack");
    [PunRPC]
    void CrouchRPC(bool isCrouch)
    {
        if(isCrouch)
        {
            col.offset = new Vector2(-0.23f, -0.3f);
            col.size = new Vector2(0.8f, 1f);
        }
        else
        {
            col.offset = new Vector2(0, 0.08f);
            col.size = new Vector2(0.8f, 1.8f);
        }
    }
    [PunRPC]
    void DestroyRPC() 
    {
        Destroy(this.gameObject);
    } 
    public void Hit()
    {
        slider_Health.value -= 10f;
        animator.SetTrigger("Damage");
        if(slider_Health.value <= 0)
        {
            GameObject.Find("Canvas").transform.Find("PlayPanel").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("RespawnPanel").gameObject.SetActive(true);
            
            photonview.RPC("DestroyRPC", RpcTarget.AllBuffered);
            audioSource.PlayOneShot(clip_GameLose);
        }
    }
  
    public void OnPhotonSerializeView(PhotonStream stream , PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(slider_Health.value);
        }
        else
        {
            curPos = (Vector3)stream.ReceiveNext();
            slider_Health.value = (float)stream.ReceiveNext();
        }
    }

}
