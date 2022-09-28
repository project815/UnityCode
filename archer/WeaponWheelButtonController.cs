using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeaponWheelButtonController : MonoBehaviour
{
    public int ID;
    private Animator anim;
    public string itemName;
    public TMP_Text itemText;
    public Image selectedItem;
    private bool selected =false;
    public Sprite icon;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selected)
        {
            selectedItem.sprite = icon;
            itemText.text = itemName;
        }
    }

    public void Selected()
    {
        selected = true;
    }
    public void Deselected()
    {
        selected = false;
    }
    public void HovoerEnter()
    {
        itemText.text = itemName;
    }
    public void HoverExit()
    {
        itemText.text = "";
    }
}
