using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    private bool isPaused;
    public GameObject pauseMenu;
    public GameObject player;
    public string scene;

    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Joystick1Button7))
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
            pauseMenu.SetActive(false);
            isPaused = false;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.GetComponent<Player>().Game_True();
        } else if (!isPaused)
            {
                pauseMenu.SetActive(true);
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                player.GetComponent<Player>().Game_False();
                Time.timeScale = 0f;                
            }
    }

    public void BackGame()
    {
        SceneManager.LoadScene(0);
    }
}
