using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimerCouting : MonoBehaviour
{
    public TextMeshPro countdownText; // Tham chiếu đến đối tượng Text để hiển thị đếm ngược
    public CatMoveController catMoveController;
    private bool isDestroyed = false;
    public Animator animator;
    private void Start()
    {
        // Khởi tạo đếm ngược
        countdownText.text = "3";

        // Bắt đầu đếm ngược
        StartCoroutine(CountdownToStart());
    }

    private IEnumerator CountdownToStart()
    {
        SoundController.instance.PlayTimePassing();
        for (int i = 3; i >= 1; i--)
        {
            
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        if (catMoveController != null)
        {
            catMoveController.EnableMovement();
        }

        isDestroyed = true; // Đặt trạng thái của đối tượng thành đã bị phá hủy
    }

    private void Update()
    {
        // Nếu đối tượng đã bị phá hủy thì phá hủy nó
        if (isDestroyed)
        {
           
            Destroy(gameObject);
        }
    }
}