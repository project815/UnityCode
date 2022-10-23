using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.AI;


public class ARmanager : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject spawnPrefab;
    List<ARRaycastHit> hits = new List<ARRaycastHit> ();

    void Update()
    {
        //PlacePrefab();
        //PlaceIndicator();
        PlayerMove();

    }


    void PlacePrefab()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began) return;

        if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
        {
            Pose hitPose = hits[0].pose;
            Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);
        }
    }
    //#region ??????????
    //public Transform Indicator;
    //List<ARRaycastHit> indicatorHits = new List<ARRaycastHit>();

    //void PlaceIndicator()
    //{
    //    arRaycaster.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), indicatorHits, TrackableType.Planes);

    //    if(indicatorHits.Count > 0)
    //    {
    //        Indicator.position = indicatorHits[0].pose.position;
    //        Indicator.rotation = indicatorHits[0].pose.rotation;

    //    }
    //}
    //public void PlaceIndicatorPrefab()
    //{
    //    Pose hitPose = indicatorHits[0].pose;
    //    Instantiate(spawnPrefab, hitPose.position, hitPose.rotation);

    //}
    //#endregion

    #region ???? ??????
    public ARPlaneManager arPlane;

    public void ShowPlane(bool b)
    {
        foreach(var plane in arPlane.trackables)
        {
            plane.gameObject.SetActive(b);
        }
    }
    #endregion

    #region ???? ????
    public ARSessionOrigin arOrigin;
    List<ARRaycastHit> originHits = new List<ARRaycastHit>();

    public void PlaceOrigin()
    {
        arRaycaster.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), originHits, TrackableType.Planes);
        if(originHits.Count > 0)
        {
            Pose hitPose = originHits[0].pose;
            arOrigin.MakeContentAppearAt(arOrigin.transform, hitPose.position, hitPose.rotation);
        }
    }
    #endregion

    //#region ?? ????
    //public ARCameraManager arCameraManager;
    //public Light currentLight;
    //void OnEnable() => arCameraManager.frameReceived += FrameUpdated;
    //void OnDisable() => arCameraManager.frameReceived -= FrameUpdated;

    //void FrameUpdated(ARCameraFrameEventArgs args)
    //{
    //    var brightness = args.lightEstimation.averageBrightness;
    //    if(brightness.HasValue)
    //    {
    //        bool isBright = brightness.Value > 0.3f;
    //        float fixBrightness = brightness.Value * 4f;
    //        currentLight.intensity = fixBrightness;
    //        print($"???? :{brightness.Value}\n ???? ???? : {fixBrightness}\n ???? : {isBright}");
    //    }
    //}
    //#endregion

    #region ???????? ???????? ????

    public NavMeshAgent agent;

    public void MoveTarget()
    {
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
        {
            agent.SetDestination(hit.point);
            agent.gameObject.GetComponent<Animator>().SetBool("isMove", true);
            if(Vector3.Distance(agent.transform.position, hit.point) < 1)
            {
                agent.gameObject.GetComponent<Animator>().SetBool("isMove", true);
            }
        }

    }
    #endregion  

    public void PlayerMove()
    {
        arOrigin.transform.position = agent.transform.position + new Vector3(0, 80, -100);
    }
}
