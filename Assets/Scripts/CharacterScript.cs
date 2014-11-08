using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {

	public int jumpHeight = 5;
	bool isJump = false;
	int frameNum = 0;
	double time = 0;
	double lastNegativeTime = -100;
	double lastAcceleration = 0;
	double lastJump = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		frameNum++;
		time += Time.deltaTime;
		double x = Input.acceleration.x;
		double y = Input.acceleration.y;
		double z = Input.acceleration.z;
		double acceleration = Math.Sqrt(x*x+y*y+z*z);
		bool isAccelJump = false;
		if (frameNum > 1 && time - lastJump > 1.5) {
			if(acceleration < 0.9){
				lastNegativeTime = time;
			}
			if(lastAcceleration > 1.5 && acceleration < lastAcceleration){
				isAccelJump = true;
				lastJump = time;
			}
		}
		lastAcceleration = acceleration;
		x = x / acceleration;
		y = y / acceleration;
		z = z / acceleration;
		int inclination = (int) Math.Round(Math.Acos(x) * 180 / Math.PI);
		float coefficient = ((float)inclination - 90) / 90.0f;
		//Debug.Log(coefficient);
		#if UNITY_EDITOR
		isAccelJump = false;
		coefficient = 0f;
		#endif
		float xvel = 0;
		Vector3 tempVel = rigidbody.velocity;
		tempVel.x = -20.0f * coefficient;
		if (!isJump && (Input.GetKey("space") || isAccelJump)) {
			tempVel.y = jumpHeight;
			isJump = true;
		}
		rigidbody.velocity = tempVel;
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "obst") {
			Debug.Log("You lose");
			RenderSettings.ambientLight = Color.red;
		} else if (other.tag == "ground") {
			Debug.Log("you are touching the ground");
			isJump = false;
			RenderSettings.ambientLight = Color.gray;
		}
	}
}
