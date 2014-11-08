using UnityEngine;
using System.Collections;

public class VariableAbyss : MonoBehaviour {

	public GameObject left;
	public GameObject middle;
	public GameObject right;

	// Use this for initialization
	void Start () {
		bool leftv = Random.Range(0,2) == 0;
		bool midv = Random.Range(0,2) == 0;
		bool rightv = Random.Range(0,2) == 0;
		left.GetComponent<MeshRenderer>().enabled = left.GetComponent<BoxCollider>().enabled = leftv;
		middle.GetComponent<MeshRenderer>().enabled = middle.GetComponent<BoxCollider>().enabled = midv;
		right.GetComponent<MeshRenderer>().enabled = right.GetComponent<BoxCollider>().enabled = rightv;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
