using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public static PetController instance;

    public Transform target;
    public float speed;
    public GameObject loseScreen;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        // Pet moves towards goal
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // When it reaches goal show lose screen
        if (transform.position == target.position)
        {
            loseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerController.instance.canInteract = false;
        }
    }
}
