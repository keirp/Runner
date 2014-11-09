using UnityEngine;
using System.Collections;

public class ReverseCameraMovement : MonoBehaviour {
	DaysOneThroughSeven godScript;
	CharacterScript charScript;
	public int pointValue = 1;
	private float speed = 7f;

	// Use this for initialization
	void Start () {
		godScript = (DaysOneThroughSeven)GameObject.Find ("God").GetComponent ("DaysOneThroughSeven");
		charScript = (CharacterScript)GameObject.Find ("Player").GetComponent ("CharacterScript");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * -speed * (charScript.isLost() ? 0 : 1), Space.World);
		if (transform.position.z < -5) {
			Destroy(gameObject);
		}
	}

	void OnDestroy() {
		godScript.incrementQ(pointValue);
	}
}