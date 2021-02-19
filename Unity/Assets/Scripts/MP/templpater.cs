using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class templpater : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        base.OnEnable();

        if (!photonView.IsMine)
        {
            Destroy(gameObject.GetComponent<templpater>());
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 0, 1);
        }
    }
}