using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextPosition : MonoBehaviour
{
    public Camera mainCamera;
    public Vector2 offset = new Vector2(10f, -10f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            // Lấy vị trí của camera trong không gian thế giới
            Vector3 cameraPosition = mainCamera.transform.position;
            // Cập nhật vị trí của scoretext
            transform.position = mainCamera.WorldToScreenPoint(cameraPosition) + new Vector3(offset.x, offset.y, 0);
        }
    }
}
