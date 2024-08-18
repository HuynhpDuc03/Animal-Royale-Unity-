using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTruck : MonoBehaviour
{
    //private void OnTriggerEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Cube")) // Đặt tag cho cube
    //    {
    //        Destroy(gameObject); // Phá hủy xe tải khi va chạm với cube
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cube")) // Đặt tag cho cube
        {
            Destroy(gameObject); // Phá hủy xe tải khi va chạm với cube
        }
    }
}


