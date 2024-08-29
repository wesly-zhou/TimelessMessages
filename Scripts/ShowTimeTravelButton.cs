using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimeTravelButton : MonoBehaviour
{
    private InventoryManager inventoryManager;
    [SerializeField]
    private GameObject timeTravelButton;
    // private GameObject intruction;
    private static bool hasTimeWatch = false;
    // Start is called before the first frame update

    public GameObject instruction;
    public GameObject MaskPanel;
    public static bool instruction_click = false;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        if(!hasTimeWatch)
            timeTravelButton.SetActive(false);
        else
        {
            timeTravelButton.SetActive(true);
            // timeTravelButton.GetComponent<Animator>().SetTrigger("Sparking");
        }
        if(instruction_click) 
                {
                    if (instruction != null )instruction.SetActive(false);
                    if (MaskPanel != null) MaskPanel.SetActive(false);
                }
    }

    // Update is called once per frame
    void Update()
    {
        if(inventoryManager.CheckItem("TimeWatch") && !hasTimeWatch)
        {
                timeTravelButton.SetActive(true);
                PlayerMovement.moveable = false;
                timeTravelButton.GetComponent<Animator>().SetTrigger("Sparking");
                hasTimeWatch = true;

                
                
        }
        
    }
}
