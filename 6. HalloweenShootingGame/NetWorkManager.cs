using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Photon.Pun;
using Photon.Realtime;
using UnityStandardAssets.CrossPlatformInput;

public class NetWorkManager : MonoBehaviourPunCallbacks
{
    private string gmaeVersion = "1";
    public TMP_InputField NickNameInput;
    public GameObject DisConnectPanel;
    public GameObject PlayPanel;
    public GameObject SettingPanel;
    public GameObject RespawnPanel;


    void Awake() {
        {
            Screen.SetResolution(960, 540, false);
            PhotonNetwork.GameVersion = this.gmaeVersion;
            PhotonNetwork.SendRate = 60;
            PhotonNetwork.SerializationRate = 30; //이렇게 숫자를 적으면 동기화가 빨리 된다고 함.
        }
    }

    public void Connect() => PhotonNetwork.ConnectUsingSettings();

    public override void OnConnectedToMaster() {
        PhotonNetwork.LocalPlayer.NickName = NickNameInput.text;
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions {MaxPlayers = 6}, null);
    }
    public override void OnJoinedRoom()
    {
        DisConnectPanel.SetActive(false);
        StartCoroutine("DestoryBullet");
        Spawn();
    }

    IEnumerator DestoryBullet()
    {
        yield return new WaitForSeconds(0.2f);
        foreach(GameObject Go in GameObject.FindGameObjectsWithTag("Bullet")) Go.GetComponent<PhotonView>().RPC("DestoryRPC", RpcTarget.All);
    }
    public void Spawn()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-9f, 20f), -4, 0), Quaternion.identity);
        PlayPanel.SetActive(true);
        RespawnPanel.SetActive(false);
        SoundManage.instance.GameLose();
    }

    void Update() {
        if (CrossPlatformInputManager.GetButtonDown("Quit") && PhotonNetwork.IsConnected) 
        {
            PhotonNetwork.Disconnect(); 
            SoundManage.instance.ButtonDownSound();
        }

    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        DisConnectPanel.SetActive(true);
        RespawnPanel.SetActive(false);
        PlayPanel.SetActive(false);
        SettingPanel.SetActive(false);
    }


}
