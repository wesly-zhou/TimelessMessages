using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    // Start is called before the first frame update
    // private bool ParentState = true;  // Assuming the parent starts active
    public float moveSpeed = 3f; 
    public float patrolDistance = 10f; 
    public bool isStatic = false;
    // Control the direction of the monster patrol
    public bool isVertical = false;
    public Animator animator;
    public int InitialDirection;
    private Rigidbody2D rb; 
    private Vector3 initialPosition; 
    private Vector3 patrolDestination;
    private Vector3 moveDirection;
    private bool isChasing = false;
    

    // private Animator animator;
    void Start()
    {
        // Debug.Log(transform.parent.parent.name);
        if(isVertical)
        {
            moveDirection = new Vector3(0, InitialDirection, 0);
        }
        else
        {
            moveDirection = new Vector3(InitialDirection, 0, 0);
        }
        // animator = GameObject.Find("Monster_Art").GetComponent<Animator>();
        if(!isStatic) animator.SetBool("isMoving", true);
        else animator.SetBool("isMoving", false);
        rb = GetComponentInParent<Rigidbody2D>();
        initialPosition = transform.parent.position;
        SetPatrolDestination();
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

        if (!isStatic && !isChasing) transform.parent.position += moveDirection * moveSpeed * Time.deltaTime;
        // Debug.Log("moveDirection" + moveDirection);
        // Debug.Log("Monster Position" + rb.position);
        // if the monster reaches the patrol destination, change direction
        if (Vector2.Distance(rb.position, patrolDestination) < 0.1f && !isChasing)
        {
            ChangeDirection();
            SetPatrolDestination();
            // backToPatrol();
        }
    }
    

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isChasing = true;
            GetComponentInParent<AIPath>().canMove = true;
            animator.SetBool("isMoving", true);
            animator.speed = 1.2f;
            Debug.Log("Player Enter the Alert Zone");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInParent<AIDestinationSetter>().enabled = true;
            
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && PlayerMovement.moveable)
        {
            isChasing = true;
            Debug.Log("Player stay in the Alert Zone");
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponentInParent<AIDestinationSetter>().enabled = true;
            GetComponentInParent<AIPath>().canMove = true;
            animator.SetBool("isMoving", true);
            animator.speed = 1.2f;
        }
    }

    // private void ParentBecameactive() {
    //     gameObject.SetActive(true);
    //     GetComponentInParent<AIDestinationSetter>().enabled = false;
    // }


    // Set the destination of the monster to patrol
    void SetPatrolDestination()
    {
        patrolDestination = initialPosition + moveDirection * patrolDistance;
        // Debug.Log("Set Destination" + patrolDestination);
    }

    void ChangeDirection()
    {
        moveDirection *= -1;
    }

    void backToPatrol()
    {
        patrolDestination = initialPosition;
    }
}
