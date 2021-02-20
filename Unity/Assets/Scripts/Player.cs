using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPunCallbacks
{
    private Vector3 begin;
    private Vector3 destination;
    private float fraction = 1;

    private bool canMove;
    public bool CanControl;
    private Rigidbody RB;

    public override void OnEnable()
    {
        base.OnEnable();

        if (PhotonNetwork.IsConnected)
        {
            if (!photonView.IsMine)
            {
                Destroy(gameObject.GetComponent<Player>());

                SetOpacity();
            }
        }

        RB = GetComponent<Rigidbody>();
        begin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        canMove = true;
    }

    void Update()
    {
        Movement();
        FractionUpdater();

        if (Input.GetKeyDown(KeyCode.Escape))//pause key
        {
            PauseTheGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            if (!PhotonNetwork.IsConnected)
            {
                FindObjectOfType<GameManager>().GameOver();
            }
        }
    }

    private void Movement()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                //locates a new destination on the right side to lerp to and starts the lerp by putting the franction on 0.
                destination = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
                fraction = 0;
                canMove = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                //locates a new destination on the left side to lerp to and starts the lerp by putting the franction on 0.
                destination = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
                fraction = 0;
                canMove = false;
            }
        }

    }

    private void FractionUpdater()
    {
        if (fraction < 1)
        {
            //updates the fraction so the lerp continues to play untill it's on the new destination.
            fraction += Time.deltaTime * 3f;
            transform.position = Vector3.Lerp(begin, destination, fraction);

            //Updates the starting location of the next lerp.
            begin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        if (fraction >= 1)
        {
            canMove = true;
        }

    }

    void PauseTheGame()
    {
        FindObjectOfType<PauzeManager>().CheckIfPaused();
    }

    void SetOpacity()
    {
        Color color;
        color = GetComponent<MeshRenderer>().material.color;

        color.g = 0.5f;
        color.b = 0.5f;
        GetComponent<MeshRenderer>().material.color = color;
    }
}
