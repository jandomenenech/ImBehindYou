using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    private string roomName = "MyRoom";

    void Start()
    {

        PhotonNetwork.ConnectUsingSettings();
    }

    public void PlayButtonClicked()
    {

        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; 
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room successfully.");
        PhotonNetwork.LoadLevel("Mapa");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Cloud.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create room: " + message);
    }


    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        base.OnMasterClientSwitched(newMasterClient);
    }



}

