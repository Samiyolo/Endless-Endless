using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSyncSelf : MonoBehaviourPunCallbacks
{
    [SerializeField] private PhotonView PView;

    public void CallUponRefresh()
    {
        PView.RPC("Refresh", RpcTarget.All, GetComponent<TextMeshProUGUI>().text);
    }
    [PunRPC]
    void Refresh(string newtext)
    {
        GetComponent<TextMeshProUGUI>().text = newtext;
    }
}