using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private InventoryManager inventoryManager;
    public static bool introLoaded = false;

    private void Start() {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    public void StartGame() {
        if (!introLoaded)
            SceneManager.LoadScene("IntroScene");
        else
            SceneManager.LoadScene("ChemLab");
    }

    public void Main() {
        SceneManager.LoadScene("MainMenu");
        introLoaded = true;
    }

    public void CreditsMain() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void OpenMenu() 
    {
        inventoryManager.OpenMenu();
        // inventoryManager.closeButton.SetActive(true);
    }        
}
