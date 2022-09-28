using UnityEngine;
public class PlayerShooter : MonoBehaviour
{

#region 변수

    [SerializeField]public Bow bowScript;
    private PlayerInput input; // 플레이어의 입력 
    private Animator animator; // 애니메이터 컴포넌트 
    private PlayerString PString;
    private Transform cam;


    [Header("AimingSettings")]
    [SerializeField]public LayerMask aimLayers;
    private RaycastHit hit;
    private Ray ray;
    private bool hitDetected;


    [Header("Spine Settings")]
    public Transform spines;
    public Vector3 spineOffset;

    [Header("HeadRotationSettings")]
    public float lookAtPoint = 50f;


#endregion

#region 초기화
    private void Awake()
    {
        if(TryGetComponent<PlayerInput>(out PlayerInput v_playerInput))
            input = v_playerInput;
        else Debug.LogError("PlayerInput is null");
        if(TryGetComponent<Animator>(out Animator v_animator))
            animator = v_animator;
        else Debug.LogError("animator is null");
        if(TryGetComponent<PlayerString>(out PlayerString playerString))
            PString = playerString;
        else Debug.LogError("playerString is null");
      
        
        cam = Camera.main.transform;
    }
#endregion

    void Update()
    {
        if(cam == null)
        {
            Debug.LogError("cam is null");
            return;
        }
        Aim();
        Fire();

    }
    void LateUpdate() {
        if(input.isFire)
        {
            fireend = false;
        }
        if(input.isAim || input.isPull || !fireend )
            RotateCharacterSpine();
    }

    public void Aim()
    {
        animator.SetBool(PString.bool_aim, input.isAim);
        animator.SetBool(PString.bool_pull, input.isPull);

        Vector3 camPostion = cam.position;
        Vector3 dir = cam.forward;

        ray = new Ray(camPostion, dir);
        if(Physics.Raycast(ray, out hit, 500f, aimLayers))
        {
            hitDetected = true;
            Debug.DrawLine(ray.origin, hit.point, Color.green);
        }
        else
        {
            hitDetected = false;
        }
    }

    public void Fire()
    {
        if(input.isFire && hitDetected)
        {
            animator.SetTrigger(PString.Triger_fire);
            bowScript.Fire(hit.point);
            bowScript.UnEquipBow();
        }
        else if(input.isFire && !hitDetected)
        {
            animator.SetTrigger(PString.Triger_fire);
            bowScript.Fire(ray.GetPoint(300f));
            bowScript.UnEquipBow();
        }
        else
        {
            bowScript.EquipBow();
        }

    }

    //애니메이션 이벤트를 통해 동작함.
    #region 애니메이션 동작도중 활과 화살의 위치
    public void EnableArrow()
    {
        bowScript.PickArrow();
    }
    public void Pull() 
    {
        bowScript.PullString();
    }
    public void DisableArrow()
    {
        bowScript.DisableArrow();
    }
    public void ReleaseString()
    {
        bowScript.ReleaseString();
    }
    #endregion


    public float num;
    //바라보는 시점으로 활 이동
    void RotateCharacterSpine()
    {
        spines.LookAt(ray.GetPoint(num));
        spines.transform.Rotate(spineOffset);
    }
    //RotateCharacterSpine에서 사용되는 코드임.
    //isfire가 클릭을 뗄 때 한 번 불려서 애니메이션이 도중에 중단되는 현상 발생.
    //이를 해결하기 위해 애니메이션 이벤트를 추가하여 그 시점까지 애니메이션이 진행되도록 함.
    bool fireend = true;
    public void FireEnd()
    {
        fireend = true;
    }

    private void OnAnimatorIK(int layerIndex) {

        animator.SetLookAtWeight(1f);
        animator.SetLookAtPosition(ray.GetPoint(lookAtPoint));

    }
}