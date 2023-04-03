using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D myRigidBody;
	private Animator MyAnimator;


	public float movementspeed;
	private bool facingRight;

	[SerializeField]
	private Transform[] GroundPoints;

	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	private bool isGrounded;
	private bool jump;
	[SerializeField]
	private float JumpForce;

	// Use this for initialization
	void Start () {
		facingRight = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		MyAnimator = GetComponent<Animator> ();


		
	}
	void Update(){
		HandleInput ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		isGrounded = IsGounded ();
		float horizontal = Input.GetAxis ("Horizontal");
		HandleMovement (horizontal);
		Flip (horizontal);
		HandleLayers ();
		ResetValues ();
		
	}
	private void HandleMovement(float horizontal){
		if (myRigidBody.velocity.y < 0) {
			MyAnimator.SetBool ("land", true); 
		}
		myRigidBody.velocity = new Vector2 (horizontal * movementspeed, myRigidBody.velocity.y);  // x= -1;
		MyAnimator.SetFloat("speed",Mathf.Abs(horizontal));

		if (isGrounded && jump) {
			isGrounded = false;
			myRigidBody.AddForce (new Vector2 (0, JumpForce));
			MyAnimator.SetTrigger ("jump");
		}

	}
	private void HandleInput(){
		if (Input.GetKeyDown(KeyCode.Space)) {
			jump = true;
		}
	}
	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			
		}
	}
	private void ResetValues(){
		jump = false;
	}
	private bool IsGounded(){
		if (myRigidBody.velocity.y <= 0) {
			foreach (Transform point in GroundPoints){
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						MyAnimator.ResetTrigger ("jump");
						MyAnimator.SetBool ("land", false);
						return true;
					}
				}
			}
		}
		return false;
			
	}
	private void HandleLayers(){
		if (!isGrounded) {
			MyAnimator.SetLayerWeight (1, 1); 
		} else {
			MyAnimator.SetLayerWeight (1, 0); 
		}
	}

}
