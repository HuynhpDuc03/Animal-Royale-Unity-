using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TruckController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float acceleration = 5f;
    private void Start()
    {

    }
    void Update()
    {
        MoveTruck();

    }

    void MoveTruck()
    {
        moveSpeed += acceleration * Time.deltaTime;
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }

   
}
