using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomManager : MonoBehaviour
{
    public int DeathNum;
    public GameObject scene;
    private bool ParentState = true;  // Assuming the parent starts active
    public GameObject Monster;
    public GameObject Player;

    // Turtorial Text for the monster puzzle
    [SerializeField]
    [TextArea]
    public String[] TutorialText;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (scene != null && scene.activeInHierarchy != ParentState)
        {
            ParentState = scene.activeInHierarchy;
            if (ParentState && Monster != null)
            {
                Debug.Log("Monster Reset");
                Debug.Log(Monster.GetComponent<AIPath>().canMove);
                // Monster.GetComponent<AIPath>().canMove = false;
                Monster.transform.Find("AlertArea").GetComponent<SpriteRenderer>().enabled = true;
                Monster.GetComponentInChildren<AIDestinationSetter>().enabled = false;
                
            }
            // ParentState = transform.parent.parent.gameObject.activeInHierarchy;
        }
    }
    
}
