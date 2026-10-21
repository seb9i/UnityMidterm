using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScriptExample : MonoBehaviour
{
	public Vector2 direction;
	public float speed = 10f;
	public Rigidbody2D myRB;
	public bool isGrounded;
	public float jumpForce = 10f;
	
	
    void Start() {
		myRB = GetComponent<Rigidbody2D>();
		isGrounded = false;
	}
	
	void movePlayer(Vector2 direction) {
		myRB.linearVelocity = new Vector2(direction.x * speed, myRB.linearVelocity.y);
	}
	
	void jumpPlayer(float jumpForce) {
		myRB.AddForce(Vector2.up * jumpForce);
	}
	
	void FixedUpdate() {
		movePlayer(direction);
	}
	
	void Update() {
		direction = Vector2.zero;
		
		if (Keyboard.current.aKey.isPressed){
			direction += Vector2.left;
		}
		if (Keyboard.current.dKey.isPressed){
			direction += Vector2.right;
		}
		if (Keyboard.current.wKey.isPressed && isGrounded){
			jumpPlayer(jumpForce);
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground"){
			isGrounded = true;

		}
	}
	
	void OnCollisionExit2D(Collision2D collision){
		isGrounded = false;
	}
	
	void OnCollisionStay2D(Collision2D collision){
		if (collision.gameObject.tag == "Ground"){
			isGrounded = true;

		}
	}
	
}
