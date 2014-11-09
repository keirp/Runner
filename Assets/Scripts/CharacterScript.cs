using UnityEngine;
using System.Collections;
using System;

public class CharacterScript : MonoBehaviour {

	public int jumpHeight = 5;
	//public Transform deathMessage;
	ReverseCameraMovement moveScript;
	//GameObject messageInstance;
	bool isJump = false;
	int frameNum = 0;
	double lastNegativeTime = -100;
	double lastAcceleration = 0;
	double lastJump = 0;
	bool isSplash = true;
	bool hasLost = true;
	float lostTime;
	double lastClickTime = 0;
	float prevMagnitude = 0;
	double time = 0;

	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		frameNum++;
		if (!hasLost && !isSplash && !isJump) {
			time += Time.deltaTime;
			transform.position += new Vector3 (0, (float)Math.Sin (time * 10) * 0.03f, 0);
		}
		double x = Input.acceleration.x;
		double y = Input.acceleration.y;
		double z = Input.acceleration.z;
		double acceleration = Math.Sqrt(x*x+y*y+z*z);
		bool isAccelJump = false;
		if (frameNum > 1 && Time.time - lastJump > 1.5) {
			if(acceleration < 0.9){
				lastNegativeTime = Time.time;
			}
			if(lastAcceleration > 1.5 && acceleration < lastAcceleration){
				isAccelJump = true;
				lastJump = Time.time;
			}
		}
		lastAcceleration = acceleration;
		x = x / acceleration;
		y = y / acceleration;
		z = z / acceleration;
		int inclination = (int) Math.Round(Math.Acos(x) * 180 / Math.PI);
		float coefficient = isSplash ? 0 : (((float)inclination - 90) / 90.0f);
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

		if (Input.GetKey(KeyCode.A) || Math.Abs(Input.gyro.rotationRateUnbiased.x) > 3) {
			object[] obj = GameObject.FindSceneObjectsOfType(typeof (GameObject));
			foreach (object o in obj) {
				GameObject g = (GameObject) o;
				float dist = g.transform.position.z - transform.position.z;
				if (dist < 5f && g.tag == "smashable") {
					Destroy(g);
				}
			}
		}
	
		if (!isSplash && hasLost && Time.time - lostTime > 3) {
			Application.LoadLevel(0);
		}

		if (transform.position.y <  -50 && !hasLost) {
			Debug.Log("You lose");
			hasLost = true;
			isSplash = false;
			lostTime = Time.time;
		}

		Vector3 magnetometer = Input.compass.rawVector;
		if (isSplash && (Input.GetKey(KeyCode.Y) || (frameNum > 1 && Math.Abs (magnetometer.magnitude - prevMagnitude) > 100 && Time.time - lastClickTime > 1))) {
			isSplash = false;
			hasLost = false;
			lastClickTime = Time.time;
		}
		prevMagnitude = magnetometer.magnitude;
	}

	void OnTriggerEnter (Collider other) {
		if (!hasLost && (other.tag == "obst" || other.tag == "smashable")) {
			Debug.Log("You lose");
			RenderSettings.ambientLight = Color.red;
			hasLost = true;
			isSplash = false;
			lostTime = Time.time;

			//messageInstance = (GameObject) Instantiate(deathMessage, new Vector3(0f, 2f, 100f), Quaternion.identity);

		} else if (other.tag == "ground") {
			Debug.Log("you are touching the ground");
			isJump = false;
			//RenderSettings.ambientLight = Color.gray;
		} else if (other.tag == "abyss") {
			gameObject.layer = 8;
		}
	}

	void OnGUI(){
		if (isSplash) {
			GUIStyle style = new GUIStyle();
			style.fontSize = 15;
			style.normal.textColor = Color.white;
			GUI.Label (new Rect (Screen.width * 0.25f-100, Screen.height/2, 400, 50), "Tap magnet to begin ", style);
			GUI.Label (new Rect (Screen.width * 0.75f-100, Screen.height/2, 400, 50), "Tap magnet to begin ", style);
		} else if (hasLost) {
			GUIStyle style = new GUIStyle();
			style.fontSize = 30;
			GUI.Label (new Rect (Screen.width * 0.25f-50, Screen.height/2, 200, 50), "You Died", style);
			GUI.Label (new Rect (Screen.width * 0.75f-53, Screen.height/2, 200, 50), "You Died", style);
		}
	}

	public bool isLost(){
		return hasLost;
	}

}
