using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public string itemDesc;
    public Sprite itemSprite;
    public bool occupied;

    [SerializeField]
    private Image itemImage;

    public GameObject selectedShader;
    public bool itemSelected;
    private InventoryManager inventoryManager;

    private void Start() {
        inventoryManager = GameObject.Find("InventoryMenu").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, string itemDesc, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemDesc = itemDesc;
        this.itemSprite = itemSprite;
        occupied = true;
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData) 
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            OnLeftClick();
    }

    public void OnLeftClick() 
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        itemSelected = true;
    }
}
