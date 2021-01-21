using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    private Rigidbody rb;
    private Vector2 moveInput;
    public Animator anim;
    private float moveDirection;
    public Camera cam;
    public bool canInteract;
    public GameObject winScreen, catchText;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
    }

    void Update()
    {
        // Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);
        anim.SetFloat("Move Speed", moveInput.x);

        // Camera Behavior
        if (transform.position.x < 8.5f)
        {
            cam.transform.position = new Vector3(0f, 0f, -10f);
        }
        else if (transform.position.x >= 8.5f && transform.position.x < 27f)
        {
            cam.transform.position = new Vector3(18f, 0f, -10f);
        }
        else if (transform.position.x >= 27f && transform.position.x < 45f)
        {
            cam.transform.position = new Vector3(36f, 0f, -10f);
        }
        else if (transform.position.x >= 45f && transform.position.x < 65f)
        {
            cam.transform.position = new Vector3(54f, 0f, -10f);
        }
        else if (transform.position.x >= 65f)
        {
            cam.transform.position = new Vector3(72f, 0f, -10f);
        }

        // Interact
        if (canInteract && Input.GetKeyDown(KeyCode.Space))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }

        // Enable/Disable Catch Text when in range of pet
        if (canInteract)
        {
            catchText.SetActive(true);
        }
        else
        {
            catchText.SetActive(false);
        }

        // Exit Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
