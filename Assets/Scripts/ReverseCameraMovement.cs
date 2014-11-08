using UnityEngine;
using System.Collections;

public class ReverseCameraMovement : MonoBehaviour {

	private float speed = 7f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * -speed, Space.World);
		if (transform.position.z < -5) {
			Destroy(gameObject);
		}
	}
}
