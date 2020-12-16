using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[SerializeField] float runSpeed = 5f;
	[SerializeField] float jumpSpeed = 5f;
	Rigidbody2D playerRigidBody;
	Animator playerAnimator;
	CapsuleCollider2D feetCollider;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		feetCollider = GetComponent<CapsuleCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Run();
		FlipSprite();
		Jump();
	}

	private void Run() {
		float inputValue = CrossPlatformInputManager.GetAxis("Horizontal");
		Vector2 playerVelocity = new Vector2 (inputValue * runSpeed, playerRigidBody.velocity.y);
		playerRigidBody.velocity = playerVelocity;

		bool isPlayerMoving = Mathf.Abs (playerRigidBody.velocity.x) > 0;
		playerAnimator.SetBool ("isWalking", isPlayerMoving);
	}

	private void Jump() {
		if(!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			playerAnimator.SetBool("isJumping", false);
			return;
		}

		if (CrossPlatformInputManager.GetButtonDown("Jump")) {
			Vector2 jumpVelocity = new Vector2 (0f, jumpSpeed);
			playerRigidBody.velocity += jumpVelocity;
			playerAnimator.SetBool("isJumping", true);
		}
	}

	private void FlipSprite() {
		bool isPlayerMoving = Mathf.Abs (playerRigidBody.velocity.x) > 0;
		if (isPlayerMoving) {
			transform.localScale = new Vector2 (Mathf.Sign (playerRigidBody.velocity.x), 1f);
		}
	}
}
