using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResumeScript : MonoBehaviour {

    GameObject pausePanel;
    GameObject controlPanel;
    bool isGamePaused = false;

    private void Awake()
    {
        pausePanel = GameObject.Find("PausePanel");
        controlPanel = GameObject.Find("ControlPanel");

        Debug.Assert(pausePanel != null);
        Debug.Assert(controlPanel != null);
    }

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;

        pausePanel.SetActive(false);

        isGamePaused = false;

        //controlPanel.SetActive(true);

    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);

        //controlPanel.SetActive(false);
        Time.timeScale = 0f;
        isGamePaused = true;

    }
}
