using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public static bool GameIsPaused = true;
    public bool FirstStart = true;
    public bool Restart = false;

    public GameObject PauseMenuUI;
    public TMP_Text PlayText;

    private void Start()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FirstStart == false)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void GameOver()
    {
        FirstStart = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        PlayText.text = "Restart";
        Restart = true;
    }

    public void StartButton()
    {
        if (!Restart)
        {
            FirstStart = false;
            PlayText.text = "Resume";
            Resume();
        }
        else SceneManager.LoadScene("Game");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
