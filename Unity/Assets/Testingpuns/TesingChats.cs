using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;
using Photon.Pun.Demo.Cockpit;

public class TesingChats : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI playerdata;
    public TextMeshProUGUI ChatBox;
    public TMP_InputField inputchat;
    public Button EnterChatText;
    private TextSyncSelf textsync;

    public Button LeaveChat;
    public TextMeshProUGUI CurrenNmbrPlayers;

    void Start()
    {
        textsync = FindObjectOfType<TextSyncSelf>();

        PhotonNetwork.AutomaticallySyncScene = true;
        playerdata.text = "Name: " + PhotonNetwork.NickName + ", Leader: " + PhotonNetwork.IsMasterClient.ToString() + "\n" + "Room: " + PhotonNetwork.CurrentRoom.Name + "\n" + "Max Players: " + PhotonNetwork.CurrentRoom.MaxPlayers;

        EnterChatText.onClick.AddListener(()=>submitText(inputchat.text));
        LeaveChat.onClick.AddListener(WantsToLeave);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);

        ChatBox.text = ChatBox.text + "\n" + "<color=yellow>" + newPlayer.NickName + " has entered the room.";

        CurrenNmbrPlayers.text = "Current Players: " + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);


        ChatBox.text = ChatBox.text + "\n" + "<color=red>" + otherPlayer.NickName + " has left the room.";

        CurrenNmbrPlayers.text = "Current Players: " + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        CurrenNmbrPlayers.text = "Current Players: " + PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public void submitText(string text)
    {
        if (inputchat.text != "")
        {
            ChatBox.text = ChatBox.text + "\n" + "<color=green>" + PhotonNetwork.NickName + ": " + "<color=white>" + text;
            textsync.CallUponRefresh();
        }

        inputchat.text = "";
    }

    void WantsToLeave()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }
}