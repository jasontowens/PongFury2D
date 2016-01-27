using UnityEngine;
using System.Collections;
 

public class Ball : MonoBehaviour {
	public float initial_speed = 30;
	public float current_speed = 30;

	float MAX_SPEED =100;

	float goalLine = 100;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.right * initial_speed;
		current_speed = initial_speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//speed += 1;
		//speed *= 1.01f;
		increaseSpeed ();
		positionCheck ();
	}
	void increaseSpeed(){
		float newXSpeed =  GetComponent<Rigidbody2D> ().velocity.x*1.01f;
		if(newXSpeed > MAX_SPEED)
			newXSpeed = MAX_SPEED;
		
		if (newXSpeed < -MAX_SPEED) {
			newXSpeed = -MAX_SPEED;
		}
		
		GetComponent<Rigidbody2D> ().velocity = new Vector2(newXSpeed, GetComponent<Rigidbody2D> ().velocity.y); //= G + 2; // * speed / 30;

	}

	void positionCheck(){
		if (GetComponent<Rigidbody2D> ().position.x > goalLine) {
			resetBall ();
			UpdateScore.player1score += 1;
			//Debug.Log ("IF BREACHED");
		} else if (GetComponent<Rigidbody2D> ().position.x < -1*goalLine) {
			resetBall ();
			UpdateScore.player2score += 1;

		}
		//Debug.Log ("positionCheck Reached " + GetComponent<Rigidbody2D> ().position.x);
		current_speed =  System.Math.Abs( GetComponent<Rigidbody2D> ().velocity.magnitude);
	}

	void resetBall(){
		GetComponent<Rigidbody2D> ().position = new Vector2(0f, 0f);
		current_speed = initial_speed;
	}

	/**
	 * 
	 * Angle Detection  
	 * 
	 * 
	 */

	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketHeight) {
		// ascii art:
		// ||  1 <- at the top of the racket
		// ||
		// ||  0 <- at the middle of the racket
		// ||
		// || -1 <- at the bottom of the racket
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void OnCollisionEnter2D(Collision2D col) {
		// Note: 'col' holds the collision information. If the
		// Ball collided with a racket, then:
		//   col.gameObject is the racket
		//   col.transform.position is the racket's position
		//   col.collider is the racket's collider
		
		// Hit the left Racket?
		if (col.gameObject.name == "kidMoco") {
			// Calculate hit Factor
			float y = hitFactor(transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.y);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(1, y).normalized;
			
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * current_speed;
		}
		
		// Hit the right Racket?
		if (col.gameObject.name == "broToss") {
			// Calculate hit Factor
			float y = hitFactor(transform.position,
			                    col.transform.position,
			                    col.collider.bounds.size.y);
			
			// Calculate direction, make length=1 via .normalized
			Vector2 dir = new Vector2(-1, y).normalized;
			
			// Set Velocity with dir * speed
			GetComponent<Rigidbody2D>().velocity = dir * current_speed;
		}
	}
}
