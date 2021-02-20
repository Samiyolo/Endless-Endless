using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tijdelijk : MonoBehaviour
{
    public Vector3 speed;
    private GameManager mana;
    private void OnEnable()
    {
        mana = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (mana.difficulty == GameManager.DifficultyState.Medium || mana.difficulty == GameManager.DifficultyState.Hard)
        {
            if (GetComponent<Collectable>() == null)
            {
                speed.x += Time.deltaTime * 5;
            }
        }

        gameObject.GetComponent<Rigidbody>().AddForce(-speed * Time.deltaTime, ForceMode.Impulse);

        if (gameObject.GetComponent<Rigidbody>().velocity.z <= -speed.z)
        {
            gameObject.GetComponent<Rigidbody>().velocity = -speed;
        }
    }
}