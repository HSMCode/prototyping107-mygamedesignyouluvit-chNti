using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
     public GameObject dog, cat, bunny, titleScreen, chooseScreen;

    void Start()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Enable/Disable Cursor when Lose or Win Screen are active/inactive
        if (PetController.instance.loseScreen.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (PlayerController.instance.winScreen.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        titleScreen.SetActive(false);
        chooseScreen.SetActive(true);
    }

    public void ChooseDog()
    {
        dog.SetActive(true);
        cat.SetActive(false);
        bunny.SetActive(false);
        chooseScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChooseCat()
    {
        cat.SetActive(true);
        dog.SetActive(false);
        bunny.SetActive(false);
        chooseScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ChooseBunny()
    {
        cat.SetActive(false);
        dog.SetActive(false);
        bunny.SetActive(true);
        chooseScreen.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

}
