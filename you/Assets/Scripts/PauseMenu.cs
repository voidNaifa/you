using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject player;
    public string scene;
    [SerializeField] private GameObject pauseButton;
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetButtonDown("Cancel") && isPaused)
        {   
            PauseGame();
        }
        if(isPaused)
        {
            Time.timeScale = 0f;
            player.GetComponent<Player>().Game_False();

        }
      
    }

    public void PauseGame()
    {
        if(isPaused)
        {
            Unpause();
        } 
        else if (!isPaused)
        {
            Pause();
        }
    }


    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        //Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        player.GetComponent<Player>().Game_False();
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseButton);        
    }
    public void Unpause()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.GetComponent<Player>().Game_True();
    }


    public void BackGame()
    {
        SceneManager.LoadScene(0);
    }
}
