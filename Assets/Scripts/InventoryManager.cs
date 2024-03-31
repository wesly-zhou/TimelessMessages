using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject closeButton;
    private bool menuActivated;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        closeButton.SetActive(false);
        menuActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OpenMenu() {
        inventoryMenu.SetActive(true);
        closeButton.SetActive(true);
        menuActivated = true;
    }        

    public void CloseMenu() {
        inventoryMenu.SetActive(false);
        closeButton.SetActive(false);
        menuActivated = false;
    }
}
