using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControllerForward : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float acceleration = 5f;
    void Update()
    {
        MoveTruck();
    }

    void MoveTruck()
    {
        moveSpeed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
