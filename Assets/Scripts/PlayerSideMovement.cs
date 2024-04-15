using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideMovement : MonoBehaviour 
{
    public Rigidbody2D player;
	private bool faceRight = true;  // determine which way player is facing.
	public float runSpeed = 5f;
    public float jumpSpeed = 8f;

    void Start() {
        player = GetComponent<Rigidbody2D>();
    }

	void Update() {
		//Horizontal axis: [a]/left arrow is -1, [d]/right arrow is 1
		Vector3 hMove = new Vector3(Input.GetAxis ("Horizontal"), 0.0f, 0.0f );
		transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

		// if input is moving player right and player faces left, turn, and vice-versa
		if ((hMove.x < 0 && faceRight) || (hMove.x > 0 && !faceRight))
        {
			Turn();
		}

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
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

    private void Jump() {

    }
}