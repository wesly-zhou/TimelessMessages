using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TextBubble;
    public GameObject TeleportDestination;
    private bool interactable = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E)) {
            GameObject.FindWithTag("Player").transform.position = TeleportDestination.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            interactable = true;
            TextBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            interactable = false;
            TextBubble.SetActive(false);
        }
    }

}
