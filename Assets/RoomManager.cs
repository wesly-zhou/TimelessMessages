using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int DeathNum;
    public GameObject scene;
    private bool ParentState = true;  // Assuming the parent starts active
    public GameObject Monster;
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
                Monster.transform.Find("AlertArea").gameObject.SetActive(true);
                Monster.GetComponentInChildren<AIDestinationSetter>().enabled = false;
                
            }
            // ParentState = transform.parent.parent.gameObject.activeInHierarchy;
        }
    }
    
}
