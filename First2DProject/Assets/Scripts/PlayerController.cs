using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public Rigidbody2D ridgidbody;
	public float moveSpeed = 30;
	public float topSpeed = 50;
	public Animator animator;
	public GameObject sprite;
	public float jumpSpeed=10;

	public bool isJumping = false;
	public LayerMask jumpingLayerMask;

	// Use this for initialization
	void Start () {
		ridgidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetInput ();
		CheckSpeed ();
		DrawSonic ();
	}

	private void GetInput(){
		if (Input.GetKey (KeyCode.D)) {
			ridgidbody.AddForce (Vector2.right * moveSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			ridgidbody.AddForce (Vector2.left * moveSpeed);
		}

		Debug.DrawRay (transform.position - (Vector3.up * 0.5f), -Vector3.up * 0.1f, Color.yellow);

		RaycastHit2D hit = Physics2D.Raycast(transform.position-(Vector3.up*0.5f), -Vector2.up,0.1f,jumpingLayerMask);

		if (hit.collider != null && ridgidbody.velocity.y <= 0) {
			if (isJumping) {
				isJumping = false;
			}
		}

		if (Input.GetKey (KeyCode.Space) && isJumping == false) {
			ridgidbody.AddForce (Vector3.up * jumpSpeed, ForceMode2D.Impulse);
			isJumping = true;
		}

	}

	public void DrawSonic(){
		animator.SetFloat("MovementSpeed", Mathf.Abs(ridgidbody.velocity.x));
		//animator.SetBool ("isJumping", isJumping);

		if (ridgidbody.velocity.x > 0) {
			sprite.transform.localScale = new Vector2 (1, 1);
		} else if (ridgidbody.velocity.x < 0) {
			sprite.transform.localScale = new Vector2 (-1, 1);
		}
	}

	private void CheckSpeed (){
		if (ridgidbody.velocity.x > topSpeed) {
			ridgidbody.velocity = new Vector2 (topSpeed, ridgidbody.velocity.y);
		} else if (ridgidbody.velocity.x < -topSpeed) {
			ridgidbody.velocity = new Vector2 (-topSpeed, ridgidbody.velocity.y);
		}
	}
}
