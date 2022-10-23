using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    GameObject GameLoseMessage;
    AudioSource SoundManAudio;
    public AudioClip Jumpclip;
    public AudioClip PlayerLoseclip;


    public float speed;
    public static float JumpPower = 5;
    public static float hAxis;
    public static float vAxis;

    GameObject SceneManager;


    bool isjump;
    bool isReload;
    bool isKill= false;


    Vector3 MoveVec;
    Rigidbody rigid;


    [SerializeField]
    private Transform cameraArm;
    [SerializeField]
    private Transform characterBody;



    private float time = 0.0f;
    private bool isMoving = false;
    private bool isJumpPressed = false;

    void Start()
    {
        Time.timeScale = 1;
        rigid = GetComponent<Rigidbody>();
        GameLoseMessage = GameObject.Find("HUD_Message").transform.Find("PlayerDeath").gameObject;
        SceneManager = GameObject.Find("SceneManager");
        SoundManAudio = GameObject.Find("SoundManager").GetComponent<AudioSource>();
            //FindObjectOfType<SoundManager>().GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JumpPos")
        {
            isjump = true;
        }
        if (other.tag == "PlayerKill")
        {
            isKill = true;
        }
        if (other.tag == "reload")
        {
            isReload = true;
        }
        if(other.tag == "star")
        {
            StarInput.Star();
        }

    }
    void FixedUpdate()
    {
        if (isjump == true)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);

            // the cube is going to move upwards in 10 units per second
            //rigid.velocity = new Vector3(0, JumpPower, 0);
            isjump = false;
            isMoving = true;
            SoundManager.instance.SFXPlay("Jump", Jumpclip);
        }

        //if (isMoving)
        //{
        //    // when the cube has moved for 10 seconds, report its position
        //    time = time + Time.fixedDeltaTime;
        //    if (time > 10.0f)
        //    {
        //        Debug.Log(gameObject.transform.position.y + " : " + time);
        //        time = 0.0f;
        //    }
        //}
        //if (isjump == true)
        //{
        //    rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
        //    isjump = false;


        //}
        //PlayerDeath
        if (isKill == true)
        {
            SoundManAudio.Pause();
            isKill = false;
            GameLoseMessage.SetActive(true);
            SoundManager.instance.SFXPlay("PlayerLose", PlayerLoseclip);
            Destroy(gameObject, PlayerLoseclip.length);
            Debug.Log("GAMEOVER");
        }
        //tutorial
        if (isReload == true)
        {
            SceneManager.GetComponent<SceneMove>().LoadScene(1);
        }
    }

    void Update()
    {
        //PlayerMove
        hAxis = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        vAxis = CrossPlatformInputManager.GetAxisRaw("Vertical");

        //hAxis = Input.GetAxis("Horizontal");
        //vAxis = Input.GetAxis("Vertical");

        if (hAxis != 0 || vAxis != 0)
        {
            MoveVec = new Vector3(hAxis, 0, vAxis).normalized;
            transform.position += (MoveVec * speed * Time.deltaTime);
            transform.LookAt(transform.position + MoveVec);
        }
        else
        {
            return;
        }
    }
    //public void Move(Vector2 inputDirection)
    //{
    //    Vector2 moveInput = inputDirection;
    //    bool isMove = moveInput.magnitude != 0;
    //    if (isMove)
    //    {
    //        Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
    //        Vector3 LookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
    //        Vector3 moveDir = lookForward * moveInput.y + LookRight * moveInput.x;
    //        characterBody.forward = moveDir;
    //        transform.position += moveDir * Time.deltaTime * 5f;
    //    }
    //}

}
