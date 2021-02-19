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

        if (!photonView.IsMine)
        {
            Destroy(gameObject.GetComponent<Player>());

            SetOpacity();
        }

        RB = GetComponent<Rigidbody>();
        begin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        canMove = true;
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Escape))//pause key
        {
            PauseTheGame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    private void Movement()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                //locates a new destination on the right side to lerp to and starts the lerp by putting the franction on 0.
                destination = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
                fraction = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                //locates a new destination on the left side to lerp to and starts the lerp by putting the franction on 0.
                destination = new Vector3(transform.position.x - 3f, transform.position.y, transform.position.z);
                fraction = 0;
            }
        }

        if (fraction < 1)
        {
            //updates the fraction so the lerp continues to play untill it's on the new destination.
            fraction += Time.deltaTime * 1.5f;
            transform.position = Vector3.Lerp(begin, destination, fraction);

            //Updates the starting location of the next lerp.
            begin = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            canMove = false;
        }
        else
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
