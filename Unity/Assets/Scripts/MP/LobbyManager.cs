using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button CreateB;
    [SerializeField] private Button BackB;
    [SerializeField] private Slider PlayerS;
    [SerializeField] private TMP_InputField RoomI;
    [SerializeField] private TMP_InputField NickNameI;
    [SerializeField] private Button NextSceneB;
    [SerializeField] private Button DisconnectB;

    public TMP_Text nickTextW;
    public TMP_Text roomNameW;

    public TMP_Text roomInfoT;

    private bool firstJoin;

    private void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        CreateB?.onClick.AddListener(TryCreate);
        BackB?.onClick.AddListener(GoBack);
        NextSceneB?.onClick.AddListener(GoNextScene);

        DisconnectB?.onClick.AddListener(DisconnectGame);
    }

    void TryCreate()
    {
        if (NickNameI.text == string.Empty)
        {
            nickTextW.gameObject.SetActive(true);
        }
        else
        {
            nickTextW.gameObject.SetActive(false);
            PhotonNetwork.NickName = NickNameI.text;
        }

        if (RoomI.text == string.Empty)
        {
            roomNameW.gameObject.SetActive(true);
        }
        else
        {
            roomNameW.gameObject.SetActive(false);
        }

        if (RoomI.text != string.Empty && NickNameI.text != string.Empty)
        {
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        PhotonNetwork.JoinOrCreateRoom(RoomI.text, new Photon.Realtime.RoomOptions() { MaxPlayers = (byte)PlayerS.value }, null);
    }

    void GoNextScene()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(4);
        }
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        PlayerS.gameObject.SetActive(false);
        NickNameI.gameObject.SetActive(false);
        RoomI.gameObject.SetActive(false);

        DisconnectB.interactable = true;
        CreateB.interactable = false;

        roomInfoT.text = "Room: " + PhotonNetwork.CurrentRoom.Name + "\nMaster: " + PhotonNetwork.IsMasterClient;
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);

        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            NextSceneB.interactable = true;
        }
        else
        {
            NextSceneB.interactable = false;
        }
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1)
        {
            NextSceneB.interactable = true;
        }
        else
        {
            NextSceneB.interactable = false;
        }
    }

    void DisconnectGame()
    {
        PhotonNetwork.Disconnect();
    }

    void GoBack()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        DisconnectB.interactable = false;

        PlayerS.gameObject.SetActive(true);
        NickNameI.gameObject.SetActive(true);
        RoomI.gameObject.SetActive(true);
        CreateB.interactable = true;
        roomInfoT.text = string.Empty;
    }
}