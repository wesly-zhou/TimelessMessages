using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
// using UnityEditor.Search;
// using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class RoomManager : MonoBehaviour
{
    public int DeathNum;
    public GameObject scene;
    private bool ParentState = true;  // Assuming the parent starts active
    public GameObject Enemy;
    // public GameObject Player;
    public GameObject textBubble;
    public PlayableDirector director;
    public GameObject UIButton;
    public GameObject Player;
    // Turtorial Text for the monster puzzle
    [SerializeField]
    [TextArea]
    public String[] TutorialText;

    [TextArea]
    public String[] DialogueText;
    // The name of last scene
    private string LastRoom;
    // If the scene have played the director
    private bool SceneAnim;
    // If player can enter the next dialogue
    private bool showNext = false;
    // The index of the current dialogue
    private int diaNum = 0;
    // If the player is in a dialogue
    private bool inDialogue = false;
    // Start is called before the first frame update
    
    void Awake()
    {
        Debug.Log("-------AWAKE---------" + PlayerMovement.moveable);

        // Get the information that if the current scene have played the director
        SceneAnim = GameManager.SceneAnim[SceneManager.GetActiveScene().name];
        PlayerMovement.moveable = true;
    }
    void Start()
    {
        Debug.Log("-------START---------" + PlayerMovement.moveable);
        // LastRoom = GameManager.LastRoom;
        if(SceneAnim || SceneManager.GetActiveScene().name == "SecurityRoom") 
            return;
        else
        {
            // Play the director
            if(director != null)
            {
                if(UIButton != null) UIButton.SetActive(false);
                PlayerMovement.moveable = false;
                Debug.Log("Issue 1");
                director.Play();
                if (DialogueText.Length > 0)
                {
                StartCoroutine(StartDialogue());
                }
                GameManager.SceneAnim[SceneManager.GetActiveScene().name] = true;
            }
        }
        Debug.Log("SceneAnim: " + GameManager.SceneAnim[SceneManager.GetActiveScene().name]);
    }

    
    // Update is called once per frame
    void Update()
    {
        // The logic of dialogue
        if (Input.GetKeyDown(KeyCode.E) && inDialogue)
        {
            Debug.Log("E is pressed! Enter the next dialogue");
            if (!showNext)
            {
                // textBubble.GetComponentInChildren<Text>().text = "";
                StopAllCoroutines();
                textBubble.GetComponentInChildren<Text>().text = DialogueText[diaNum];
                showNext = true;
                textBubble.GetComponentInChildren<Image>().enabled = true;
                // diaNum++;
            }
            else if(diaNum < DialogueText.Length - 1)
            {
                diaNum++;
                StartCoroutine(TypeDialogue(DialogueText[diaNum]));
            }
            else
            {
                textBubble.SetActive(false);
                PlayerMovement.moveable = true;
                Debug.Log("Issue get solved 1");
                UIButton.SetActive(true);
                inDialogue = false;
            }
        }

        // Reset the monster when scene change
        
        if (scene != null && scene.activeInHierarchy != ParentState)
        {
            ParentState = scene.activeInHierarchy;
            if (ParentState && Enemy != null)
            {
                Debug.Log("Monster Reset");
                Debug.Log(Enemy.GetComponent<AIPath>().canMove);
                // Monster.GetComponent<AIPath>().canMove = false;
                Enemy.transform.Find("AlertArea").GetComponent<SpriteRenderer>().enabled = true;
                Enemy.GetComponentInChildren<AIDestinationSetter>().enabled = false;
                
            }
            // ParentState = transform.parent.parent.gameObject.activeInHierarchy;
        }
    }

    private IEnumerator TypeDialogue(string sentence)
    {
        textBubble.GetComponentInChildren<Image>().enabled = false;
        // textBubble.SetActive(true);
        textBubble.GetComponentInChildren<Text>().text = "";
        showNext = false;
        foreach (char letter in sentence.ToCharArray())
        {
            // If player press E in advance, show the whole sentence
            
            textBubble.GetComponentInChildren<Text>().text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        textBubble.GetComponentInChildren<Image>().enabled = true;
        showNext = true;
    }

    private IEnumerator StartDialogue()
    {
        
        
        // Wait for the director to finish
        if(director != null && !SceneAnim) {
            Debug.Log("Waiting for Director Duration and enter dialogue: " + (float)director.duration);
            yield return new WaitForSeconds((float)director.duration);
            }
        inDialogue = true;
        if (DialogueText.Length > 0){
            textBubble.SetActive(true);
            // The first dialogue will be shown automatically
            yield return StartCoroutine(TypeDialogue(DialogueText[0]));
            // yield return Input.GetKeyDown(KeyCode.E);
            // while(!Input.GetKeyDown(KeyCode.E))
            // {
            //     yield return null;
            // }
            // if (diaNum < DialogueText.Length && showNext)
            // {
            //         // textBubble.GetComponentInChildren<Text>().text = "";
            //         showNext = false;
            //         yield return StartCoroutine(TypeDialogue(DialogueText[diaNum]));
            //         diaNum++;
            //         // yield return Input.GetKeyDown(KeyCode.E);
            //     // diaNum++;
                
            // }
            
        }
        else
        {
            inDialogue = false;
            textBubble.SetActive(false);
            PlayerMovement.moveable = true;
            Debug.Log("Issue get solved 2");
            UIButton.SetActive(true);
        }
 
        // textBubble.SetActive(false);
        // PlayerMovement.moveable = true;
        // UIButton.SetActive(true);
        
    }
    // Create a function for outside to trigger the dialogue
    public void TriggerDialogue()
    {
        if (DialogueText.Length > 0)
            {
                // Player face to camera
            Player.GetComponentInChildren<Animator>().SetInteger("direction", 3);
            if(UIButton != null) UIButton.SetActive(false);
            PlayerMovement.moveable = false;
            Debug.Log("Issue 2");
            StartCoroutine(StartDialogue());
            }
    }
}
