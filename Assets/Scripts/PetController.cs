using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public static PetController instance;

    public Transform target;
    public float speedDog, speedCat, speedBunny;
    public GameObject loseScreen;
    public UIManager uiman;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        // Pet moves towards goal
        if(uiman.pickedDog == true){
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedDog * Time.deltaTime);
        }
        if(uiman.pickedCat == true){
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedCat * Time.deltaTime);
        }
        if(uiman.pickedBunny == true){
        transform.position = Vector3.MoveTowards(transform.position, target.position, speedBunny * Time.deltaTime);
        }

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
