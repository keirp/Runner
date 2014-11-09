using UnityEngine;
using System.Collections;
using System;

public class ShiftingWall : MonoBehaviour {
	public float period;
	public float cycle;
	float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		transform.localPosition = new Vector3 ((float) Math.Sin(2 * Math.PI * time / period) * cycle, 
		                                        transform.localPosition.y, transform.localPosition.z);
	}
}
