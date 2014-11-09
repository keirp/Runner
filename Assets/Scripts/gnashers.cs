using UnityEngine;
using System.Collections;
using System;

public class gnashers : MonoBehaviour {
	public float phase = 0;
	public float period = 3;

	// Use this for initialization
	void Start () {
		if (phase == 0) {
			phase = Math.Abs(transform.localPosition.x) / 10f + (float) (Time.time % period);
		}
		phase *= period;
	}
	
	// Update is called once per frame
	void Update () {
		phase += Time.deltaTime;
		if (phase > 3) {
			phase = phase % 3;
		}
		if (phase < 0.05 * period) {
			transform.localScale = new Vector3 (transform.localScale.x, 200f * phase / period, transform.localScale.z);
		} else if (phase < 0.25 * period) {
			transform.localScale = new Vector3 (transform.localScale.x, 50f * (.25f - phase/period), transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (transform.localScale.x, 0, transform.localScale.z);
		}
	}
}
