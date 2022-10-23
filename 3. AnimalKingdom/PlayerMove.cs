using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
    
    Rigidbody playerRigibody;

    public static bool isCamel;
    public static bool isLizard;
    public static bool isElephant;
    public static bool isLeopard;
    public static bool isRhino;
    public static bool isZebra;

    public float speed;

    public AudioClip clip_DesertMove;
    public AudioClip clip_ForestMove;
    public AudioClip clip_WaterMove;

    AudioSource audioSource;

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRigibody = GetComponent<Rigidbody>();    
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "camel")
        {
            isCamel = true;
        }
        if (other.tag == "lizard")
        {
            isLizard = true;
        }
        if (other.tag == "elephant")
        {
            isElephant = true;
        }
        if (other.tag == "leopard")
        {
            isLeopard = true;
        }
        if (other.tag == "rhino")
        {
            isRhino = true;
        }
        if (other.tag == "zebra")
        {
            isZebra = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //float hAxis = Input.GetAxis("Horizontal");
        //float vAxis = Input.GetAxis("Vertical");
        float hAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        float vAxis = CrossPlatformInputManager.GetAxis("Vertical");
        float xSpeed = hAxis * speed;
        float ySpeed = vAxis * speed;

        Vector3 MoveVec = new Vector3(xSpeed, 0, ySpeed);
        transform.position += speed * Time.deltaTime * MoveVec;
        transform.LookAt(transform.position + MoveVec);
        GetComponent<Animator>().SetBool("isMove", (hAxis != 0 || vAxis != 0) ? true : false);
        if((hAxis != 0 || vAxis !=0)&&audioSource.isPlaying == false)
        {
            if (PlayerMessager.val == 0 || PlayerMessager.val == 1) 
                audioSource.PlayOneShot(clip_DesertMove);
            if (PlayerMessager.val == 2)
            {
                audioSource.PlayOneShot(clip_WaterMove);
                audioSource.volume = 1f;
            }
            if (PlayerMessager.val == 3)
                audioSource.PlayOneShot(clip_ForestMove);
            if (PlayerMessager.val == 4)
            {
                audioSource.PlayOneShot(clip_WaterMove);
                audioSource.volume = 1f;
            }
            if (PlayerMessager.val == 5|| PlayerMessager.val == 6)
                audioSource.PlayOneShot(clip_ForestMove);

        }
        else if((hAxis == 0 || vAxis == 0))
        {
            audioSource.Pause();
        }
    }
}
