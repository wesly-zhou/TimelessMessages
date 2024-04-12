using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ParentState = true;  // Assuming the parent starts active

    void Start()
    {
        // Debug.Log(transform.parent.parent.name);
    }

    // Update is called once per frame
    void Update()
    {
        // // Reset the monster when scene change
        // // Debug.Log("active");
        // bool curParentState = transform.parent.parent.gameObject.activeInHierarchy;
        // // Debug.Log(curParentState);
        // if (transform.parent.parent != null && curParentState != ParentState)
        // {
        //     ParentState = transform.parent.parent.gameObject.activeInHierarchy;
        //     if (ParentState)
        //     {
        //         Debug.Log("Monster Reset");
        //         ParentBecameactive();
        //     }
        //     // ParentState = transform.parent.parent.gameObject.activeInHierarchy;
        // }
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponentInParent<AIPath>().canMove = true;
            Debug.Log("Player Enter the Alert Zone");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInParent<AIDestinationSetter>().enabled = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && PlayerMovement.moveable)
        {
            Debug.Log("Player stay in the Alert Zone");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInParent<AIDestinationSetter>().enabled = true;
            GetComponentInParent<AIPath>().canMove = true;
        }
    }

    // private void ParentBecameactive() {
    //     gameObject.SetActive(true);
    //     GetComponentInParent<AIDestinationSetter>().enabled = false;
    // }

    
}
