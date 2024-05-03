using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TextBubble;
    public GameObject FinalDoorPanel;
    private bool interactable = false;
    public static bool isOpen = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E)) {
            FinalDoorPanel.SetActive(true);
            
            TextBubble.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !isOpen) {
            TextBubble.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            TextBubble.SetActive(false);
            interactable = false;
        }
    }
}
