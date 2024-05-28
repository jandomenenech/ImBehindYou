using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using System.Linq;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    private string roomName = "MyRoom";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        Debug.Log("Te has desconectado");
        SceneManager.LoadScene(0);
    }

    public void DisconnectAndGoToMenu()
    {
        PhotonNetwork.Disconnect();
    }


}

