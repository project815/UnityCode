using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMessager : MonoBehaviour
{
    public GameObject camel_message;
    public GameObject lizard_message;
    public GameObject elephant_message;
    public GameObject leopard_message;
    public GameObject rhino_message;
    public GameObject zebra_message;


    public GameObject camel_icon;
    public GameObject lizard_icon;
    public GameObject elephant_icon;
    public GameObject leopard_icon;
    public GameObject rhino_icon;
    public GameObject zebra_icon;


    Slider slider_green;
    public static float val;



    void Awake()
    {

        slider_green = GameObject.Find("HUD").gameObject.GetComponentInChildren<Slider>();
        slider_green.value = val;
        if (PlayerMove.isCamel == true) Destroy(camel_message);
        if (PlayerMove.isLizard == true) Destroy(lizard_message);
        if (PlayerMove.isElephant == true) Destroy(elephant_message);
        if (PlayerMove.isLeopard == true) Destroy(leopard_message);
        if (PlayerMove.isRhino == true) Destroy(rhino_message);
        if (PlayerMove.isZebra == true) Destroy(zebra_message);

    }

    void Update()
    {
        if(PlayerMove.isCamel && slider_green.value <= 0)
        {
            val = 1;
            camel_message.SetActive(true);
        }
        if (PlayerMove.isLizard && slider_green.value <= 1)
        {
            val = 2;
            lizard_message.SetActive(true);
        }
        if (PlayerMove.isElephant && slider_green.value <= 2)
        {
            val = 3;
            elephant_message.SetActive(true);
        }
        if (PlayerMove.isRhino && slider_green.value <= 3)
        {
            val = 4;
            rhino_message.SetActive(true);

        }
        if (PlayerMove.isLeopard && slider_green.value <= 4)
        {
            val = 5;
            leopard_message.SetActive(true);

        }
        if (PlayerMove.isZebra&& slider_green.value <= 5)
        {
            val = 6;
            zebra_message.SetActive(true);
        }

        if (PlayerMove.isCamel) camel_icon.SetActive(true);
        if (PlayerMove.isLizard) lizard_icon.SetActive(true);
        if (PlayerMove.isElephant) elephant_icon.SetActive(true);
        if (PlayerMove.isRhino) rhino_icon.SetActive(true);
        if (PlayerMove.isLeopard) leopard_icon.SetActive(true);
        if (PlayerMove.isZebra) zebra_icon.SetActive(true);

    }
}
