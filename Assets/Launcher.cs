using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView player;
    
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnConnectedToMaster(){
        Debug.Log("conectado!");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public void OnJoinedRoom(){
        PhotonNetwork.Instantiate(player.name,spawnPoint.position,spawnPoint.rotation);
    }
}
