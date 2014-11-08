using UnityEngine;
using System.Collections;

public class DaysOneThroughSeven : MonoBehaviour {

	public Transform hurdle;
	private float lastTime = 0.0f;
	private float spawnInt = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastTime > spawnInt) {
			lastTime = Time.time;
			Instantiate(hurdle, transform.position, Quaternion.identity);
		}
	}

	void PreventApocalypse() {

	}

}
