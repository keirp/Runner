using UnityEngine;
using System.Collections;

public class gnashers : MonoBehaviour {
	public float phase = 0;
	public float period = 3;

	// Use this for initialization
	void Start () {
		if (phase == 0) {
			phase = transform.localPosition.x / 10f;
		}
		phase *= period;
	}
	
	// Update is called once per frame
	void Update () {
		phase += Time.deltaTime;
		if (phase > 3) {
			phase = 0;
		}
		if (phase < 0.1 * period) {
			transform.localScale = new Vector3 (transform.localScale.x, 100f * phase / period, transform.localScale.z);
		} else if (phase < 0.5 * period) {
			transform.localScale = new Vector3 (transform.localScale.x, 25f * (.5f - phase/period), transform.localScale.z);
		} else {
			transform.localScale = new Vector3 (transform.localScale.x, 0, transform.localScale.z);
		}
	}
}
