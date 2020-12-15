using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	[SerializeField] float runSpeed = 5f;
	Rigidbody2D playerRigidBody;
	Animator playerAnimator;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Run();
		FlipSprite();
	}

	private void Run() {
		float inputValue = CrossPlatformInputManager.GetAxis("Horizontal");
		Vector2 playerVelocity = new Vector2 (inputValue * runSpeed, playerRigidBody.velocity.y);
		playerRigidBody.velocity = playerVelocity;

		bool isPlayerMoving = Mathf.Abs (playerRigidBody.velocity.x) > 0;
		playerAnimator.SetBool ("isWalking", isPlayerMoving);
	}

	private void FlipSprite() {
		bool isPlayerMoving = Mathf.Abs (playerRigidBody.velocity.x) > 0;
		if (isPlayerMoving) {
			transform.localScale = new Vector2 (Mathf.Sign (playerRigidBody.velocity.x), 1f);
		}
	}
}
