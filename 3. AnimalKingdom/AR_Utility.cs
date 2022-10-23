using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_Utility : MonoBehaviour
{
    private static ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    static AR_Utility()
    {
        raycastManager = GameObject.FindObjectOfType<ARRaycastManager>();
    }
    public static bool Raycast(Vector2 screenPosition, out Pose pose)
    {
        if (raycastManager.Raycast(screenPosition, hits, TrackableType.Planes))
        {
            pose = hits[0].pose;
            return true;
        }
        else
        {
            pose = Pose.identity;
            return false;

        }
    }
    public static bool TryGetInputPostion(out Vector2 position)
    {
        
        position = Vector2.zero;

        if(Input.touchCount == 0)
        {
            return false;
        }

        position = Input.GetTouch(0).position;

        if(Input.GetTouch(0).phase != TouchPhase.Began)
        {
            return false;
        }
        return true;
    }
}
