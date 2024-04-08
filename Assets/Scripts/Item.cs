using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [TextArea]
    [SerializeField]
    private string itemDesc;

    [SerializeField]
    private Sprite sprite;

    public InventoryManager inventoryManager;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player") 
        {
            inventoryManager.AddItem(itemDesc, sprite);
            Destroy(gameObject);
        }
    }
}
