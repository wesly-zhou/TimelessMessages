using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockedDoorHandler : MonoBehaviour
{
    private InventoryManager inventoryManager;
    public bool unlocked;
    public bool unlockable;
    public bool interactable;
    public string keyRequired = "BioLabKey";
    public string newLevel = "MainMenu";
    public GameObject unlockDoorBubble;
    public GameObject missingKeyBubble;
    public int state = 0;
    public AudioSource doorOpenSFX;
    public GameObject player;
    // Use an empty gameobject to define a new position for the player to spawn in the new level
    public GameObject newPoisiton;
    // Start is called before the first frame update
    private void Start()
    {
        unlockDoorBubble.SetActive(false);
        missingKeyBubble.SetActive(false);
        unlocked = false;
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && unlocked == false && state == 0) {
            unlockDoorBubble.SetActive(true);
        }
        else if (other.gameObject.tag == "Player" && unlocked == false && state == 1) {
            missingKeyBubble.SetActive(true);
        }
        interactable = true;
        // else if (other.gameObject.tag == "Player" && unlocked == true) {
            
        // }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player" && unlocked == true) { 
            StartCoroutine(OpenDoor());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        interactable = false;
        unlockDoorBubble.SetActive(false);
        missingKeyBubble.SetActive(false);
        if (!unlocked)
            state = 0;
    }

    void Update()
    {
        for (int i = 0; i < inventoryManager.itemSlot.Length; i++) {
            if (inventoryManager.itemSlot[i].itemName == keyRequired) {
                unlockable = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.F) && !unlockable && interactable) {
            unlockDoorBubble.SetActive(false);
            missingKeyBubble.SetActive(true);
            state = 1;
        }
        else if (Input.GetKeyDown(KeyCode.F) && unlockable && interactable) {
            unlockDoorBubble.SetActive(false);
            state = 2;
            if (doorOpenSFX.isPlaying == false) {
                doorOpenSFX.Play();
            }
            unlocked = true;
        }
    }

    public IEnumerator OpenDoor() 
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene (newLevel);
    }

    // Relocated the player based on the last room when the new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        // On scene load, move the player to the new position
        Debug.Log("Moving player to new position" + newPoisiton.transform.position);
        Debug.Log("Last Room: " + GameManager.LastRoom + " New Level: " + newLevel);
        if(newPoisiton != null && GameManager.LastRoom == newLevel) {  // The new scene of the door actually is the last scene of the player
            
            player.transform.position = newPoisiton.transform.position;
            GameManager.LastRoom = SceneManager.GetActiveScene().name;
        }
    }

    
    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
