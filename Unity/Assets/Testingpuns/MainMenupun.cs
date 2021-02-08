using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenupun : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI slidertext;
    public Button multiplayer;
    public Button joinmp;
    public Button SubmitUserName;
    public Button StartGame;
    public TextMeshProUGUI textuihelp;
    public TMP_InputField usernameinput;

    private string roomName;
    private int maxPlayers;
    public TMP_InputField setroomname;
    public Slider maxplayerslider;

    private bool join;
    private bool create;

    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        multiplayer.onClick.AddListener(StartMultiplayer);
        joinmp.onClick.AddListener(JoinMultiplayer);
        SubmitUserName.onClick.AddListener(OnSubmitUserName);
        StartGame.onClick.AddListener(startTheGame);
        maxplayerslider.onValueChanged.AddListener(changevaluenumber);

        multiplayer.gameObject.SetActive(false);
        joinmp.gameObject.SetActive(false);
        StartGame.gameObject.SetActive(false);

        setroomname.gameObject.SetActive(false);
        maxplayerslider.gameObject.SetActive(false);
        slidertext.gameObject.SetActive(false);
    }

    public void StartMultiplayer()
    {
        if (setroomname.text != "")
        {
            create = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    void JoinMultiplayer()
    {
        if (setroomname.text != "")
        {
            join = true;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        roomName = setroomname.text;
        maxPlayers = Mathf.RoundToInt(maxplayerslider.value);

        if (create)
        {
            PhotonNetwork.CreateRoom(roomName, new Photon.Realtime.RoomOptions() { MaxPlayers = (byte)maxPlayers }, null);
        }
        if (join)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
    }

    void OnSubmitUserName()
    {
        if (usernameinput.text != "")
        {
            PhotonNetwork.NickName = usernameinput.text;
            usernameinput.gameObject.SetActive(false);
            multiplayer.gameObject.SetActive(true);
            joinmp.gameObject.SetActive(true);
            setroomname.gameObject.SetActive(true);
            maxplayerslider.gameObject.SetActive(true);
            slidertext.gameObject.SetActive(true);
        }
    }

    void changevaluenumber(float v)
    {
        slidertext.text = "Max Players: " + v;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel(4);
        textuihelp.text = "waiting on leader/opponents";

        slidertext.gameObject.SetActive(false);
        maxplayerslider.gameObject.SetActive(false);
        setroomname.gameObject.SetActive(false);
        multiplayer.gameObject.SetActive(false);
        joinmp.gameObject.SetActive(false);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {
            textuihelp.text = "player joined starting";
            StartGame.gameObject.SetActive(PhotonNetwork.IsMasterClient);
            multiplayer.gameObject.SetActive(false);
        }
    }

    void startTheGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount > 1 && PhotonNetwork.CurrentRoom.PlayerCount <= maxPlayers && PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(4);
        }
    }
}