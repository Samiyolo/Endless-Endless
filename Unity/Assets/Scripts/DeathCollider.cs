using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class DeathCollider : MonoBehaviourPunCallbacks
{
    public GameManager gameManager;

    private void OnTriggerExit(Collider other)
    {
        KillGame();
    }

    void KillGame()
    {
        if (!PhotonNetwork.IsConnected)
        {
            Destroy(gameManager.playerOBJ);
            gameManager.GameOver();
        }
        else
        {
            PlayerPrefs.SetFloat("Score", gameManager.score);
            PlayerPrefs.SetString("Name", PhotonNetwork.NickName);
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Disconnect();
            }
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        SceneManager.LoadScene(5);
    }
}