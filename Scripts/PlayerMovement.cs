using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //You can adjust the speed in the Unity editor
    public float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRend;
    private Vector2 movement;
    private bool faceRight = true;
    public Sprite forward;
    public Sprite back;
    public Sprite right;
    // public GameObject playerArt;

    public static bool moveable = true;
    public AudioSource walkSound;//sound effect

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim =  GetComponentInChildren<Animator>();
        spriteRend = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!moveable)
        {
            return;
        }
        
        Vector3 hvMove = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        // transform.position = transform.position + hvMove * moveSpeed * Time.deltaTime;
        
        // Stop
        if (hvMove.x == 0 && hvMove.y == 0){
            anim.SetInteger("direction", 3);
        }
        
        // Change walk status
        if (hvMove.y < 0){
            anim.SetInteger("direction", 0);
            spriteRend.sprite = forward;
        } 
        if (hvMove.y > 0){
            anim.SetInteger("direction", 1);
            spriteRend.sprite = back;
        } 
        if (hvMove.x < 0 || hvMove.x > 0){
            anim.SetInteger("direction", 2);
            spriteRend.sprite = right;
            // Turn left or right
            if ((hvMove.x <0 && faceRight) || (hvMove.x >0 && !faceRight)){
            // anim.SetInteger("direction", 2);
            Debug.Log ("Time to turn!");
                playerTurn();
            
            }
        }
        // play sound effect
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            
            if (!walkSound.isPlaying)
            {
                //audioSource.clip = walkSound;
                walkSound.Play();
            }
        }
        else
        {
            
            walkSound.Stop(); // Stop the sound if the player is not moving
        }
    }

    void FixedUpdate()
    {
        //movement
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (!moveable)
        {
            return;
        }
        Vector2 position = rb.position;
        position.x += Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        position.y += Input.GetAxis("Vertical") * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }

    public void playerTurn()
    {
        // NOTE: Switch player facing label
        faceRight = !faceRight;
        Debug.Log("FaceRight = " + faceRight);
        // NOTE: Multiply player's x local scale by -1.
        Vector3 theScale = GameObject.FindWithTag("PlayerArt").transform.localScale;
        theScale.x = theScale.x * -1;
        GameObject.FindWithTag("PlayerArt").transform.localScale = theScale;
        Debug.Log("the Scale = " + theScale);
    }

    
}
