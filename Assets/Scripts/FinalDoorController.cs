using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinalDoorController : MonoBehaviour
{
    public string newLevel;
    public GameObject TextBubble;
    public GameObject secondTextBubble;
    public GameObject FinalDoorPanel;
    private bool interactable = false;
    public static bool isOpen = false;
    void Start()
    {
        FinalDoorPanel.SetActive(false);
        TextBubble.SetActive(false);
        secondTextBubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen) {
            secondTextBubble.SetActive(true);
        }
        if (isOpen && Input.GetKeyDown(KeyCode.E)) {
            SceneManager.LoadScene(newLevel);
        }
        if (!isOpen && interactable && Input.GetKeyDown(KeyCode.E)) {
            FinalDoorPanel.SetActive(true);
            TextBubble.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && !isOpen) {
            TextBubble.SetActive(true);
            interactable = true;
        }
        if (other.gameObject.tag == "Player" && isOpen) {
            secondTextBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            TextBubble.SetActive(false);
            secondTextBubble.SetActive(false);
        }
    }
}
