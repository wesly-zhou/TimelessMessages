using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
        isPaused = false;
    }
    
    public void Pause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void openSettings() {
        settingsPanel.SetActive(true);
    }

    public void closeSettings() {
        settingsPanel.SetActive(false);
    }
}
