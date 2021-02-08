using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool CanControl;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(-3);//right movement
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(3);//left movement
        }
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

    void MovePlayer(int side)//positive is right, negative left
    {
        if (CanControl)
        {
            transform.position = new Vector3(transform.position.x - side, transform.position.y, transform.position.z);
        }
    }
    void PauseTheGame()
    {
        FindObjectOfType<PauzeManager>().CheckIfPaused();
    }
}