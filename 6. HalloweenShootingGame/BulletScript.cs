using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class BulletScript : MonoBehaviourPunCallbacks
{
    public PhotonView photonview;

    int dir;

    void Start() => Destroy(gameObject, 3.5f);
    void Update() => transform.Translate(Vector3.right * 7 * Time.deltaTime * dir);

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground") photonview.RPC("DestroyRPC", RpcTarget.AllBuffered);

        if(!photonview.IsMine && other.tag == "Player" && other.GetComponent<PhotonView>().IsMine)
        {
            other.GetComponent<PlayerScript>().Hit();
            photonview.RPC("DestroyRPC", RpcTarget.AllBuffered);
        }
    }
    [PunRPC]
    void DirRPC(int dir) => this.dir = dir;

    [PunRPC]
    void DestroyRPC() => Destroy(gameObject);
}
