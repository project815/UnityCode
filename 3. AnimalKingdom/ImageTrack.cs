using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.SceneManagement;
public class ImageTrack : MonoBehaviour
{
    public ARTrackedImageManager manager;

    public List<GameObject> list1 = new List<GameObject>();

    private Dictionary<string, GameObject> dict1 = new Dictionary<string, GameObject>();

    void Start()
    {
        foreach (GameObject o in list1)
        {
            dict1.Add(o.name, o);
        }
    }
    void OnEnable()
    {
        manager.trackedImagesChanged += OnChanged;
    }
    void OnDisable()
    {
        manager.trackedImagesChanged -= OnChanged;
    }
    
    void OnChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage t in args.added)
        {
            UpdateImage(t);
        }
        foreach(ARTrackedImage t in args.updated)
        {
            UpdateImage(t);
        }
    }
    void UpdateImage(ARTrackedImage t)
    {
        string name = t.referenceImage.name;
        GameObject o = dict1[name];
        


        
        o.SetActive(true);
    }
    
}
