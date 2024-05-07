using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuzzleOneTutorial : MonoBehaviour
{
    private static bool isTriggered = false;
    public GameObject tutorialTextBubble;
    public GameObject RoomManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !isTriggered)
        {
            isTriggered = true;
            tutorialTextBubble.SetActive(true);
            tutorialTextBubble.GetComponentInChildren<Text>().text = RoomManager.GetComponent<RoomManager>().TutorialText[0];
            StartCoroutine(WaitAndHideTutorial());
        }

        IEnumerator WaitAndHideTutorial() {
            // justDied = false;
            yield return new WaitForSeconds(5);
            tutorialTextBubble.SetActive(false);
        
    }
    }
}
