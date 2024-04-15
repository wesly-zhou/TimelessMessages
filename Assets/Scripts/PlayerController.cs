using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int DeathNum;
    private static bool justDied = false;
    public GameObject RoomManager;
    public GameObject tutorialTextBubble;
    
    // Start is called before the first frame update

    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
    Debug.Log("Scene loaded: " + scene.name);
    // On scene load, show the tutorial based on the death number of player
    // Get the death number of player base on the current scene
    int deathNum = GameManager.DeathNum[scene.name];
    // switch(SceneManager.GetActiveScene().name){
    //     case "TestLab":
    //         deathNum = GameManager.TestLab;
    //         break;
    //     case "ChemLab":
    //         deathNum = GameManager.ChemLab;
    //         break;
    //     case "SecurityRoom":    
    //         deathNum = GameManager.SecurityRoom;
    //         break;
    //     case "BioLab":        
    //         deathNum = GameManager.BioLab;
    //         break;

    // }
    ShowTutorial(deathNum);
    }

    private void ShowTutorial(int deathNum) {
        Debug.Log("DeathNum: " + GameManager.DeathNum[SceneManager.GetActiveScene().name]);
        if(RoomManager != null && RoomManager.GetComponent<RoomManager>().TutorialText != null){
            if (RoomManager.GetComponent<RoomManager>().TutorialText.Length >= deathNum && justDied) {
                
                // Debug.Log("DeathNum: " + DeathNum);
                // Show the hint based on the death number
                switch(deathNum) {
                    case 0:
                        break;
                    case 1:
                        tutorialTextBubble.SetActive(true);
                        tutorialTextBubble.GetComponentInChildren<Text>().text = RoomManager.GetComponent<RoomManager>().TutorialText[0];
                        StartCoroutine(WaitAndHideTutorial());
                        break;
                    case 2:
                        tutorialTextBubble.SetActive(true);
                        tutorialTextBubble.GetComponentInChildren<Text>().text = RoomManager.GetComponent<RoomManager>().TutorialText[1];
                        StartCoroutine(WaitAndHideTutorial());
                        break;
                    case 3:
                        tutorialTextBubble.SetActive(true);
                        tutorialTextBubble.GetComponentInChildren<Text>().text = RoomManager.GetComponent<RoomManager>().TutorialText[2];
                        StartCoroutine(WaitAndHideTutorial());
                        break;
                    default:
                        break;
                }
        }
        else if(RoomManager.GetComponent<RoomManager>().TutorialText.Length < deathNum && justDied){
            tutorialTextBubble.SetActive(true);
            tutorialTextBubble.GetComponentInChildren<Text>().text = RoomManager.GetComponent<RoomManager>().TutorialText[RoomManager.GetComponent<RoomManager>().TutorialText.Length - 1];
            StartCoroutine(WaitAndHideTutorial());
        }
        }
    }

    IEnumerator WaitAndHideTutorial() {
        justDied = false;
        yield return new WaitForSeconds(5);
        tutorialTextBubble.SetActive(false);
        
    }
    void Start()
    {
        // PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When player is hit by the enemy, player dies
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Player has been hit by the Enemy");
            GameManager.DeathNum[SceneManager.GetActiveScene().name] += 1;
            // Make sure that the text bubble will shown just when player dies
            justDied = true;
            // DeathNum = GameManager.TestLab + 1;
            // PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, DeathNum + 1);
            // RoomManager.GetComponent<RoomManager>().DeathNum = DeathNum;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
