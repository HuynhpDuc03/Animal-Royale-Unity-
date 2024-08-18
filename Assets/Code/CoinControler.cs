using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControler : MonoBehaviour
{
    public float rotationSpeed = 90.0f; // Tốc độ xoay của coin

    private bool isCollected = false; // Trạng thái xác định xem coin đã được thu thập hay chưa

    private void Update()
    {
        if (!isCollected)
        {
            // Xoay vật thể coin xung quanh trục Y
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y + rotationSpeed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCollected && other.CompareTag("Player"))
        {
            Destroy(gameObject);
            // Ví dụ: PlayerController.AddScore(3);
        }
    }
}
