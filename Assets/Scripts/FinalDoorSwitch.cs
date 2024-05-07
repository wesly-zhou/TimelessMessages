using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorSwitch : MonoBehaviour
{
    public GameObject finalDoor;
    public GameObject interactBubble;
    public bool canActivate;
    private static bool switchUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        finalDoor.SetActive(false);
        interactBubble.SetActive(false);
        canActivate = false;
        if (switchUsed) {
            finalDoor.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !switchUsed) 
        {
            interactBubble.SetActive(true);
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            interactBubble.SetActive(false);
            canActivate = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.E)) {
            switchUsed = true;
            finalDoor.SetActive(true);
            finalDoor.GetComponent<Animator>().Play("ShowFinalDoor");
        }
    }
}
