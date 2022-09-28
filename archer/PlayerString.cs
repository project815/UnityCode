using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerString : MonoBehaviour
{
    [Header("InputSetting")]
    public string forwardInput = "Vertical";
    public string rightInput = "Horizontal";
    public string aim = "Aim";
    public string pull = "Pull";
    public string fire = "Fire";
    public string touch = "Touch";

    [Header("AnimationString")]
    public string bool_run = "isRun";
    public string bool_aim = "isAim";
    public string triger_aim = "doAim";
    public string bool_pull = "isPullString";
    public string bool_fire = "isFire";
    public string Triger_fire = "fire";

}
