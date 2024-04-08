using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject closeButton;
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        closeButton.SetActive(false);
    }

    public void OpenMenu() 
    {
        inventoryMenu.SetActive(true);
        closeButton.SetActive(true);
    }        

    public void CloseMenu() 
    {
        inventoryMenu.SetActive(false);
        closeButton.SetActive(false);
    }

    public void AddItem(string itemName, string itemDesc, Sprite itemSprite) 
    {
        for (int i = 0; i < itemSlot.Length; i++) {
            if (itemSlot[i].occupied == false) {
                itemSlot[i].AddItem(itemName, itemDesc, itemSprite);
                return;
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++) 
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].itemSelected = false;
        }
    }
}
