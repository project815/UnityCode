using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageLerp : MonoBehaviour
{
    RawImage image;
    void Awake()
    {
        image = GetComponent<RawImage>();    
    }
    public void Image_O()
    {
        image.color = new Color(0, 0, 1, 1);
    }
    public void Image_X()
    {
        image.color = new Color(1, 0, 0, 1);
    }
    // Update is called once per frame
    void Update()
    {


        image.color = Color.Lerp(image.color, new Color(0, 0, 0, 0), 0.05f);

        //소리 쓸 때 time필요할 것 같음.
    }
}
