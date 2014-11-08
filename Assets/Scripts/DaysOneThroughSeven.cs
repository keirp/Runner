﻿using UnityEngine;
using System.Collections;

public class DaysOneThroughSeven : MonoBehaviour {

	public Transform hurdle;
	public Transform marker;
	private float lastObst = 0.0f;
	private float obstSpawnInt = 2.0f;
	private float lastMarker = 0.0f;
	private float markerSpawnInt = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastObst > obstSpawnInt) {
			lastObst = Time.time;
			Instantiate(hurdle, new Vector3(.52f, 1.21f, transform.position.z), Quaternion.identity);
		}
		if (Time.time - lastMarker > markerSpawnInt) {
			lastMarker = Time.time;
			//Instantiate(marker, new Vector3(.78f, ), Quaternion.identity);
		}
	}

	void PreventApocalypse() {

	}

}
