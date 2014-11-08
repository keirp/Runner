using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {

	public int jumpHeight = 5;
	bool isJump = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		double x = Input.acceleration.x;
		double y = Input.acceleration.y;
		double z = Input.acceleration.z;
		double totalAcceleration = Math.Sqrt(x*x+y*y+z*z);
		bool isAccelJump = totalAcceleration < 0.3;
		#if UNITY_EDITOR
		isAccelJump = false;
		#endif
		if (!isJump && (Input.GetKey("space") || isAccelJump)) {
			Vector3 tempVel = rigidbody.velocity;
			tempVel.y = jumpHeight;
			rigidbody.velocity = tempVel;
			isJump = true;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "obst") {
			Debug.Log("You lose");
			rigidbody.position.Set(0f, -1000f, 0f);
		} else if (other.tag == "ground") {
			Debug.Log("you are touching the ground");
			isJump = false;
		}
	}
}
