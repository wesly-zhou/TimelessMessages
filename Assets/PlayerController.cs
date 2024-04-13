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
    ShowTutorial();
    }

    private void ShowTutorial() {
        Debug.Log("DeathNum: " + GameManager.TestLab);
        if (RoomManager.GetComponent<RoomManager>().TutorialText.Length >= GameManager.TestLab && justDied) {
            
            // Debug.Log("DeathNum: " + DeathNum);

            switch(GameManager.TestLab) {
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
    else if(RoomManager.GetComponent<RoomManager>().TutorialText.Length < GameManager.TestLab && justDied){
        tutorialTextBubble.SetActive(true);
        tutorialTextBubble.GetComponentInChildren<Text>().text = RoomManager.GetComponent<RoomManager>().TutorialText[RoomManager.GetComponent<RoomManager>().TutorialText.Length - 1];
        StartCoroutine(WaitAndHideTutorial());
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Player has been hit by the Enemy");
            GameManager.TestLab += 1;
            justDied = true;
            // DeathNum = GameManager.TestLab + 1;
            // PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, DeathNum + 1);
            // RoomManager.GetComponent<RoomManager>().DeathNum = DeathNum;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
