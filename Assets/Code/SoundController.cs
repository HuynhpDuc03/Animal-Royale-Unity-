using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // Khai báo các biến âm thanh cần quản lý
    public AudioClip Orange;
    public AudioClip carCrash;
    public AudioClip catMeow;
    public AudioClip eating;
    public AudioClip collectCoin;
    public AudioClip traficHighway;
    public AudioClip timePassing;

    // Thêm các âm thanh khác nếu cần

    // Âm thanh được sử dụng bởi các đối tượng khác trong game
    public static SoundController instance;

    private AudioSource audioSource;

    private void Awake()
    {
        // Singleton pattern: Đảm bảo chỉ có một instance của SoundController tồn tại
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Phương thức để phát âm thanh "Walk"
    public void PlayOrange()
    {
        audioSource.PlayOneShot(Orange);
    }

    // Phương thức để phát âm thanh "Sit"
    public void PlayCarCrash()
    {
        audioSource.PlayOneShot(carCrash);
    }

    // Phương thức để phát âm thanh khi thu thập tiền xu
    public void PlayCoinCollect()
    {
        audioSource.PlayOneShot(collectCoin);
    }
    // Phương thức để phát âm thanh tiếng mèo kêu
    public void PlayCatSound()
    {
        audioSource.PlayOneShot(catMeow);
    }
    // Phương thức để phát âm thanh khi ăn đồ vật
    public void PlayCatEatting()
    {
        audioSource.PlayOneShot(eating);
    }
    // Phương thức để phát âm thanh khi xe chạy
    public void PlayTrafficUrban()
    {
       
        AudioSource.PlayClipAtPoint(traficHighway, transform.position);

    }
    // Phương thức để phát âm thanh khi thời gian đếm ngược
    public void PlayTimePassing()
    {
        audioSource.PlayOneShot(timePassing);
    }
}
