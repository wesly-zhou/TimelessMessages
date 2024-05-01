using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [TextArea]
    [SerializeField]
    private string itemDesc;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    public GameObject RoomManager;

    private void Start() {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        if(inventoryManager.CheckItem(itemName))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            inventoryManager.AddItem(itemName, itemDesc, sprite);
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (itemName == "TimeWatch" && RoomManager != null)
        {
            RoomManager.GetComponent<RoomManager>().TriggerDialogue();
        }
    }
}
