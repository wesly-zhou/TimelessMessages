using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void PauseResume() {
        if (isPaused) {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        isPaused = !isPaused;
    }
}
