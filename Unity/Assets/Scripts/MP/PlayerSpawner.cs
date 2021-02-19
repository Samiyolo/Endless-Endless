using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private string m_playerPrefabStr = string.Empty;
    [SerializeField] private GameObject spawnLoc;

    private void Awake()
    {
        if (PhotonNetwork.InRoom)
        {
            //int i = 0;
            //foreach (var item in PhotonNetwork.CurrentRoom.Players)
            //{
            //    i = item.Key;
            //    break;
            //}

            GameObject go = PhotonNetwork.Instantiate(m_playerPrefabStr, spawnLoc.transform.position, spawnLoc.transform.rotation);
            go.name += PhotonNetwork.NickName;
        }

        Destroy(GetComponent<PlayerSpawner>());
    }
}