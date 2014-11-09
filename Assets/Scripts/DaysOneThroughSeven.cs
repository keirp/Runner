using UnityEngine;
using System.Collections;

public class DaysOneThroughSeven : MonoBehaviour {

	public Transform hurdle;
	public Transform marker;
	public Transform abyss;
	public Transform gnasher;
	public Transform popper;
	public Transform slidingWall;
	public Transform smashableWall;
	private float lastObst = 0.0f;
	private float obstSpawnInt = 3.0f;
	private float lastMarker = 0.0f;
	private float markerSpawnInt = 5.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastObst > obstSpawnInt) {
			lastObst = Time.time;
			int obst = Random.Range(0, 6);
			switch (obst) {
			case 0:
				Instantiate(hurdle, new Vector3(.52f, 1.21f, transform.position.z), Quaternion.identity);
				break;
			case 1:
				Instantiate(abyss, new Vector3(-7.643703f, 1.229f, transform.position.z), Quaternion.identity);
				break;
			case 2:
				Instantiate(gnasher, new Vector3(-3.33f, 0f, transform.position.z), Quaternion.identity);
				Instantiate(gnasher, new Vector3(0f, 0f, transform.position.z), Quaternion.identity);
				Instantiate(gnasher, new Vector3(3.33f, 0f, transform.position.z), Quaternion.identity);
				break;
			case 3:
				Instantiate(popper, new Vector3(0f, 0f, transform.position.z), Quaternion.identity);
				break;
			case 4:
				Instantiate(slidingWall, new Vector3(0f, 6f, transform.position.z), Quaternion.identity);
				break;
			case 5:
				Instantiate(smashableWall, new Vector3(0f, 6f, transform.position.z), Quaternion.identity);
				break;
			}

		}
		if (Time.time - lastMarker > markerSpawnInt) {
			lastMarker = Time.time;
			//Instantiate(marker, new Vector3(.78f, ), Quaternion.identity);
		}
	}

	void PreventApocalypse() {

	}

}
