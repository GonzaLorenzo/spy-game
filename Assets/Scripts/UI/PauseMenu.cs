using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject  pausePanel;
    private bool        isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
        
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        pausePanel.SetActive(isPaused);
    }

    public void PauseGame()
    {
        var screenPause = Instantiate(Resources.Load<ScreenPause>("PauseCanvas"));
        ScreenManager.Instance.Push(screenPause);
    }
}
