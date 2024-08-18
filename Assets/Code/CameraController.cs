using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float smoothSpeed = 1;
    private Vector3 originalOffset = new Vector3(0, 0.52f, -1.118f);
    private Vector3 reversedOffset;
    private bool isReversed = false;

    private void Start()
    {
        reversedOffset = originalOffset;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = isReversed ? target.position + reversedOffset : target.position + originalOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }

    public void ReverseCameraPosition()
    {
        isReversed = !isReversed;

        if (isReversed)
        {
            // Thiết lập vị trí đảo ngược theo góc độ mong muốn
            reversedOffset.z = 1.118f; // Khoảng cách -6.344f so với con vật
            transform.rotation = Quaternion.Euler(0, 180, 0); // Quay camera 180 độ
        }
        else
        {
            // Khôi phục lại reversedOffset ban đầu
            reversedOffset.z = -1.118f; // Khoảng cách ban đầu
            transform.rotation = Quaternion.identity; // Đặt lại góc quay ban đầu
        }
    }
}
