using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMovement : MonoBehaviour 
{
    public Rigidbody2D player;
	private bool faceRight = true;  // determine which way player is facing.
	public float runSpeed = 7f;
    private float direction = 0f;
    public float jumpSpeed = 11f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    private Animator playerAnimation;

    void Start() {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponentInChildren<Animator>();
    }

    void Update() {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isTouchingGround)
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        playerAnimation.SetBool("OnGround", isTouchingGround);
    }

	void FixedUpdate() {
        if (!PlayerMovement.moveable)
            return;
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		direction = Input.GetAxis("Horizontal");
		if (direction != 0f)
            player.velocity = new Vector2(direction * runSpeed, player.velocity.y);
        else 
            player.velocity = new Vector2(0, player.velocity.y);

		if ((direction < 0 && faceRight) || (direction > 0 && !faceRight))
        {
			Turn();
		}

        if (player.velocity.y < 0)
            player.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (player.velocity.y > 0 && !Input.GetButton ("Jump"))
            player.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
	}

	private void Turn()
	{
		// Switch player facing label
		faceRight = !faceRight;

		// Multiply player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}