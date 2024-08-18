using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatMoveController : MonoBehaviour
{
    public float defaultForwardSpeed = 3f;
    public float defaultBackwardSpeed = 1.5f;
    private float forwardSpeed;
    private float backwardSpeed;
    private float speedBoostDuration = 5f;
    private float speedBoostTimer = 0f;
    private Rigidbody rb;
    public CameraController Camera;
    private bool canMove = false;
    public bool isBlocked = false;
    private Animator animator;
    public GameObject scoretext;
    private int score = 0;
    private Coroutine scalingCoroutine;
    public GameObject  buff;
    public GameManager gameManager;
    //private bool hasPlayedSitAnimation = false;

    private void Start()
    {
        InitializeDefaults();
        scoretext.GetComponent<TextMeshPro>().text = "Score: " + 0;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleSpeedBoost();
        HandleMovement();
    }
    private void HandleSpeedBoost()
    {
        if (speedBoostTimer > 0)
        {
            // Tăng tốc độ trong thời gian speedBoostDuration.
            forwardSpeed = defaultForwardSpeed + 3.5f;
            backwardSpeed = defaultBackwardSpeed + 3.5f;
            speedBoostTimer -= Time.deltaTime;
        }
        else
        {


            InitializeDefaults();
        }

    }

    private void HandleMovement()
    {
        if (canMove)
        {
            // Tạo một Raycast từ vị trí của con vật xuống dưới.
            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 0.5f))
            {
                if (hit.collider.CompareTag("Glass"))
                {
                    // Con vật đứng trên lề đường
                    if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
                    {
                        rb.velocity = Vector3.right * forwardSpeed;
                        animator.Play("walk");
                    }
                    else
                    {
                        rb.velocity = Vector3.zero; // Dừng di chuyển khi không bấm Space.

                        // Đặt Animator sang trạng thái "sitting."
                        animator.SetBool("IsSitting", true);

                        //animator.Play("sit");

                        animator.Play("sitting");

                    }
                }
                else
                {
                    // Con vật không đứng trên lề đường
                    if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
                    {
                        rb.velocity = Vector3.right * forwardSpeed;
                    }
                    else
                    {
                        rb.velocity = -Vector3.right * backwardSpeed;
                        animator.SetBool("IsSitting", false);
                    }
                }
            }
            else
            {
                if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
                {
                    rb.velocity = Vector3.right * forwardSpeed;
                }
                else
                {
                    rb.velocity = -Vector3.right * backwardSpeed;
                    animator.SetBool("IsSitting", false);
                }
            }
        }
    }
    private void InitializeDefaults()
    {
        forwardSpeed = defaultForwardSpeed;
        backwardSpeed = defaultBackwardSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            HandleCoinCollect(other);
        }
        else if (other.CompareTag("Gift"))
        {
            HandleGiftCollect(other);
        }
        else if (other.CompareTag("obstacle"))
        {
            HandleObstacleCollision();
        }
    }


    private void HandleCoinCollect(Collider coinCollider)
    {
        Camera.ReverseCameraPosition();
        score = score + 5;
        scoretext.GetComponent<TextMeshPro>().text = "Score: " + score.ToString();
        SoundController.instance.PlayCoinCollect();
        Destroy(coinCollider.gameObject);
    }
    private void HandleGiftCollect(Collider giftCollider)
    {

        speedBoostTimer = speedBoostDuration;

        // Stop the existing coroutine if it's running
        if (scalingCoroutine != null)
        {
            StopCoroutine(scalingCoroutine);
        }

        scalingCoroutine = StartCoroutine(ScaleCatOverTime(new Vector3(1f, 1f, 1f), 5f));


        SoundController.instance.PlayOrange();
        SoundController.instance.PlayCatEatting();
        Destroy(giftCollider.gameObject);
    }

    private void HandleObstacleCollision()
    {
        gameManager.ShowGameOver(score);
        gameObject.SetActive(false);
        SoundController.instance.PlayCarCrash();
        SoundController.instance.PlayCatSound();
    }
    private IEnumerator ScaleCatOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsed = 0.5f;
        buff.SetActive(true);
        while (elapsed < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale; 
        scalingCoroutine = null;

        yield return new WaitForSeconds(0.5f);

        scalingCoroutine = StartCoroutine(ScaleCatOverTime(new Vector3(2.5f, 2.5f, 2.5f), 2f));
        buff.SetActive(false);

    }

    public void EnableMovement()
    {
        canMove = true;
    }
}
