using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    private GameManager manager;

    private void OnEnable()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        manager.SpawnObject();
    }
}