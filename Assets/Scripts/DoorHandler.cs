using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public string newLevel;
    public GameObject player;
    // Use an empty gameobject to define a new position for the player to spawn in the new level
    public GameObject newPoisiton;
    public GameObject TextBubble;
    private bool interactable = false;


    void Update()
    {
        if (interactable && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(newLevel);
        }
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        // On scene load, move the player to the new position
        Debug.Log("Current Scene: " + scene.name);
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

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            TextBubble.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            TextBubble.SetActive(false);
            interactable = false;
        }
    }
}
