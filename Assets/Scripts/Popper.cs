using UnityEngine;
using System.Collections;

public class Popper : MonoBehaviour {
	public float warning;
	bool up = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.z < warning && !up) {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y + transform.localScale.y, transform.localPosition.z);
			up = true;
		}
	}
}
