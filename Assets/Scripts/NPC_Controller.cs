using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class NPC_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TextBubble;
    // public PlayableDirector Timeline;
    public TimelineAsset FinalAnimation;
    public GameObject DialogueBubble;
    public String[] RequirementItems;
    private bool interactable = false;
    private InventoryManager InventoryManager;
    public PlayableDirector director;
    void Start()
    {
        InventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E)) {
            foreach(String item in RequirementItems) {
                if (!InventoryManager.CheckItem(item)) {
                    StopAllCoroutines();
                    DialogueBubble.GetComponentInChildren<Text>().text = "Hurry up and find the " + item + "!";
                    DialogueBubble.GetComponentInChildren<Image>().enabled = false;
                    TextBubble.SetActive(false);
                    DialogueBubble.SetActive(true);
                    StartCoroutine(WaitAndHideDialogue());
                    return;
                }
            }
            if (director != null) {
                TextBubble.SetActive(false);
                interactable = false;
                director.playableAsset = FinalAnimation;
                director.Play();
            }
            
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

    IEnumerator WaitAndHideDialogue() {
        yield return new WaitForSeconds(3);
        DialogueBubble.SetActive(false);
    }
}
