using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    public string itemName;
    public string itemDesc;
    public Sprite itemSprite;
    public bool occupied;
    public Sprite emptySprite;

    [SerializeField]
    private Image itemImage;

    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionText;

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
        itemDescriptionText.text = itemDesc;
        itemDescriptionImage.sprite = itemSprite;
        if (itemDescriptionImage.sprite == null)
            itemDescriptionImage.sprite = emptySprite;
    }
}
