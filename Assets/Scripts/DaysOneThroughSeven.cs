using UnityEngine;
using System.Collections;
using System;

public class DaysOneThroughSeven : MonoBehaviour {

	public Transform hurdle;
	public Transform marker;
	public Transform abyss;
	public Transform gnasher;
	public Transform popper;
	public Transform slidingWall;
	private float lastObst = 0.0f;
	private float obstSpawnInt = 3.0f;
	private float lastMarker = 0.0f;
	private float markerSpawnInt = 5.0f;
	public int Q = 0;
	CharacterScript charScript;

	// Use this for initialization
	void Start () {
		charScript = (CharacterScript)GameObject.Find ("Player").GetComponent ("CharacterScript");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastObst > obstSpawnInt && !charScript.isLost ()) {
			lastObst = Time.time;
			int obst = BinomialRandom((float)(1f-1f/Math.Pow(Q, 0.3)),5.0f);
			switch (obst) {
				case 0:
					Instantiate(abyss, new Vector3(-7.643703f, 1.229f, transform.position.z), Quaternion.identity);
					break;
				case 1:
					Instantiate(hurdle, new Vector3(.52f, 1.21f, transform.position.z), Quaternion.identity);
					break;
				case 2:
					Instantiate(popper, new Vector3(0f, 0f, transform.position.z), Quaternion.identity);
					break;
				case 3:
					Instantiate(gnasher, new Vector3(-3.33f, 1.7f, transform.position.z), Quaternion.identity);
					Instantiate(gnasher, new Vector3(0f, 1.7f, transform.position.z), Quaternion.identity);
					Instantiate(gnasher, new Vector3(3.33f, 1.7f, transform.position.z), Quaternion.identity);
					break;
				case 4:
					Instantiate(slidingWall, new Vector3(0f, 6f, transform.position.z), Quaternion.identity);
					break;
			}

		}
		if (Time.time - lastMarker > markerSpawnInt) {
			lastMarker = Time.time;
			//Instantiate(marker, new Vector3(.78f, ), Quaternion.identity);
		}
	}

	int BinomialRandom(float prob, float max){
		int sum = 0;
		for (int i=0; i< max; i++) {
			sum += (UnityEngine.Random.Range(0,100)/100f) < prob ? 1 : 0;
		}
		return sum;
	}

	public void incrementQ (int num){
		Q+=num;
	}

	void OnGUI(){
		GUI.Label (new Rect (Screen.width*0.25f-40, Screen.height*0.7f, 100, 20), "Your score is " + Q);
		GUI.Label (new Rect (Screen.width*0.75f-40, Screen.height*0.7f, 100, 20), "Your score is " + Q);
	}

	void PreventApocalypse() {

	}

}
