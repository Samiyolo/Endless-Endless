using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class WinLoseScree : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text PNameT;
    [SerializeField] private TMP_Text ScoreT;
    [SerializeField] private Button MainMenuB;
    [SerializeField] private Button QuitB;

    private void Start()
    {
        MainMenuB.onClick.AddListener(GoMain);
        QuitB.onClick.AddListener(DoQuit);

        if (PhotonNetwork.IsConnected)
        {
            PNameT.text = PlayerPrefs.GetString("Name");
            ScoreT.text = "Your Score is " + PlayerPrefs.GetFloat("Score");
        }
        else
        {
            PNameT.text = "Player";
            ScoreT.text = "Your Score is " + PlayerPrefs.GetFloat("Score");
        }
    }


    void GoMain()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        SceneManager.LoadScene(0);
    }

    void DoQuit()
    {
        Application.Quit();
    }
}