using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tijdelijk : MonoBehaviour
{
    public Vector3 speed;

    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(-speed * Time.deltaTime, ForceMode.Impulse);

        if (gameObject.GetComponent<Rigidbody>().velocity.z <= -speed.z)
        {
            gameObject.GetComponent<Rigidbody>().velocity = -speed;
        }
    }
}