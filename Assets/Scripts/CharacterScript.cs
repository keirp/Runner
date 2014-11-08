using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {

	public int jumpHeight = 5;
	private bool isJump = false;
	float height = 0;
	double velocity = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		double x = Input.acceleration.x;
		double y = Input.acceleration.y;
		double z = Input.acceleration.z;
		double acceleration = Math.Sqrt(x*x+y*y+z*z);
		acceleration = (acceleration - 1) * 9.8;
		velocity += acceleration * Time.deltaTime;
		height += (float) velocity * Time.deltaTime;
		if (Math.Abs(acceleration) < 0.5) {
			velocity = -height * 3;
		}
		if (Input.GetKey("space") || (totalAcceleration < 0.3 && !isJump)) {
			Vector3 tempVel = rigidbody.velocity;
			tempVel.y = jumpHeight;
			rigidbody.velocity = tempVel;
		}
		isJump = totalAcceleration < 0.3;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "obst") {
			Debug.Log("You lose");
			rigidbody.position.Set(0f, -1000f, 0f);
		}
	}
}
