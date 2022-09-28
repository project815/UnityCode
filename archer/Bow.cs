using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
#region 변수    
    [System.Serializable]
    public class  BowSettings
    {
        [Header("ArrtowSettings")]
        public float arrowCount;
        public Rigidbody arrowPrefab;
        public Transform arrowPos;
        public Transform arrowEquipParent;
        public float arrowForce = 10;

        [Header("Bow Equip & UnEquip Settings")]
        public Transform EquipPos;
        public Transform UnEquipPos;
        public Transform EquipParent;
        public Transform UnEquopParent;

        [Header("Bow String Settings")]
        public Transform bowString;
        public Transform stringInitialPos;
        public Transform stringHandPullPos;
        public Transform stringInitialParent;

    }
    [SerializeField]    
    public BowSettings bowSettings;

    Rigidbody currentArrow;

    bool canPullString = false;
    bool canFireArrow = false;
#endregion

    public void PickArrow()
    {
        bowSettings.arrowPos.gameObject.SetActive(true);
    }
    public void DisableArrow()
    {
        bowSettings.arrowPos.gameObject.SetActive(false);
    }
    public void PullString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringHandPullPos.position;
        bowSettings.bowString.transform.parent = bowSettings.stringHandPullPos;
    }
    public void ReleaseString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringInitialPos.position;
        bowSettings.bowString.transform.parent = bowSettings.stringInitialParent;
    }


    public void EquipBow()
    {
        this.transform.position = bowSettings.EquipPos.position;
        this.transform.rotation = bowSettings.EquipPos.rotation;
        this.transform.parent = bowSettings.EquipParent;
    }

    public void UnEquipBow()
    {
        this.transform.position = bowSettings.UnEquipPos.position;
        this.transform.rotation = bowSettings.UnEquipPos.rotation;
        this.transform.parent = bowSettings.UnEquopParent;
    }

    public void Fire(Vector3 hitPoint)
    {
        Vector3 dir = hitPoint - bowSettings.arrowPos.position;
        currentArrow = Instantiate(bowSettings.arrowPrefab, bowSettings.arrowPos.position, bowSettings.arrowPos.rotation) as Rigidbody;
        
        currentArrow.AddForce(dir.normalized * bowSettings.arrowForce, ForceMode.Force);
    }
}
