using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCreateChunk : MonoBehaviour
{
    private GameObject ParentObstacle;

    private void OnEnable()
    {
        ParentObstacle = gameObject.transform.parent.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(ParentObstacle);
    }
}