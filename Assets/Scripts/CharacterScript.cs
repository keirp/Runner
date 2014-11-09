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
	double prevMagnitude = 0;
	double lastClickTime = 0;
	bool isDead = false;

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		Input.compass.enabled = true;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDead) {
			Input.compass.enabled = true;
		}
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

		if (Math.Abs(Input.gyro.rotationRateUnbiased.x) > 3 || Input.GetKey(KeyCode.A)) {
			object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
			foreach (object o in obj) {
				GameObject g = (GameObject) o;
				if (g.tag == "smashable") {
					Debug.Log("hihi");
					float dist = g.transform.position.z - transform.position.z;
					Debug.Log(dist);
					if (dist < 7f) {
						Debug.Log(dist);
						Destroy(g);
					}
				}
			}
		}

		Vector3 magnetometer = Input.compass.rawVector;
		if (time - lastClickTime > 1 && Math.Abs (magnetometer.magnitude - prevMagnitude) > 100) {
			Application.LoadLevel(0);
			lastClickTime = time;
		}
		prevMagnitude = magnetometer.magnitude; // make global double prevMagnitude

		if(transform.localPosition.y < -50){
			Application.LoadLevel(0);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "obst" || other.tag == "smashable") {
			Debug.Log("You lose");
			isDead = true;
			RenderSettings.ambientLight = Color.red;
			Application.LoadLevel(0);
		} else if (other.tag == "ground") {
			Debug.Log("you are touching the ground");
			isJump = false;
			RenderSettings.ambientLight = Color.gray;
		} else if (other.tag == "abyss") {
			isDead = true;
			gameObject.layer = 8;
		}
	}
}
