using UnityEngine;
using System.Collections;



public class UpdateScore : MonoBehaviour {
	public static float player1score = 0;
	public static float player2score = 0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<TextMesh> ().text =  player1score + "-" + player2score;
	}
}
