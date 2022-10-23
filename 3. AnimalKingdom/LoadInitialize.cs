using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR.ARFoundation;



public class ARLoadManager : MonoBehaviour
{
    public void Deintiailize()
    {
        LoaderUtility.Deinitialize();
    }
    public void Initilalize()
    {
        LoaderUtility.Initialize();
    }
}
