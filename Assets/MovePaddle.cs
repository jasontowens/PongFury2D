using UnityEngine;
using System.Collections;

public class MovePaddle : MonoBehaviour {

	public float speed = 60; 
	public string axis = "Vertical";
	//public string axis2 = "Vertical2";

	public float xpos;
	public float ypos;

	public float verticalBounds = 50;
	
	void FixedUpdate () {
		float v = Input.GetAxisRaw(axis);
		float h = Input.GetAxisRaw("Horizontal");

		xpos = GetComponent<Rigidbody2D>().position.x;
		ypos = GetComponent<Rigidbody2D>().position.y;

		if(ypos<verticalBounds && ypos> -1*verticalBounds )
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
		else
			GetComponent<Rigidbody2D>().position = new Vector2(xpos, ypos *.95f);

	}

	void Start(){
		xpos = GetComponent<Rigidbody2D>().position.x;
		ypos = GetComponent<Rigidbody2D>().position.y;
	}

	// Use this for initialization
	//void Start () {
	//
	//}
	
	// Update is called once per frame
	//void Update () {
		//FixedUpdate ();
	//}
}
