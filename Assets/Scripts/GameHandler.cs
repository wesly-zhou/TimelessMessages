using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    private InventoryManager inventoryManager;

    private void Start() {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        
    }

    public void StartGame() {
        SceneManager.LoadScene("IntroScene");
    }

    public void Main() {
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
        inventoryManager.inventoryMenu.SetActive(true);
        inventoryManager.closeButton.SetActive(true);
    }        
}
