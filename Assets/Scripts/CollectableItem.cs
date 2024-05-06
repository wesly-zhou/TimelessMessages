using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [TextArea]
    [SerializeField]
    private string itemDesc;
    [SerializeField]
    private Sprite sprite;
    public GameObject item;
    public GameObject borderItem;
    public GameObject collectBubble;
    bool collectable = true;

    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    private void Start()
    {   
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        item.SetActive(true);
        borderItem.SetActive(false);
        collectBubble.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            item.SetActive(false);
            borderItem.SetActive(true);
            collectBubble.SetActive(true);
            collectable = true;
        }
    }
    void Update() {
        if (collectable && Input.GetKeyDown(KeyCode.E)) {
            inventoryManager.AddItem(itemName, itemDesc, sprite);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        item.SetActive(true);
        borderItem.SetActive(false);
        collectBubble.SetActive(false);
        collectable = false;
    }
}
