using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerExit(Collider other)
    {
        KillGame();
    }

    void KillGame()
    {
        Destroy(gameManager.playerOBJ);
        gameManager.GameOver();
    }
}