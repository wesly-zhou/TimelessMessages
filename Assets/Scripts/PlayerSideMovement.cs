using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMovement : MonoBehaviour 
{
    public Rigidbody2D player;
	private bool faceRight = true;  // determine which way player is facing.
	public float runSpeed = 8f;
    public float jumpSpeed = 12f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void Start() {
        player = GetComponent<Rigidbody2D>();
    }

	void Update() {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
		//Horizontal axis: [a]/left arrow is -1, [d]/right arrow is 1
		Vector3 hMove = new Vector3(Input.GetAxis ("Horizontal"), 0.0f, 0.0f );
		transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

		// if input is moving player right and player faces left, turn, and vice-versa
		if ((hMove.x < 0 && faceRight) || (hMove.x > 0 && !faceRight))
        {
			Turn();
		}

        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isTouchingGround) {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if (player.velocity.y < 0)
            player.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        else if (player.velocity.y > 0 && !Input.GetButton ("Jump"))
            player.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
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