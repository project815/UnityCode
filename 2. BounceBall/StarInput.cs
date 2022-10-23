using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarInput : MonoBehaviour
{
    public static float starCount;

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        starCount = 5;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "LEFT STAR : " + starCount;
    }

    public static void Star()
    {
        starCount -= 0.5f; //Why 0.5??? 

    }
}
