using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) {
			camera.Translate(new Vector3(0,0.1f));
		}
		if (Input.GetKey ("s")) {
			camera.Translate(new Vector3(0,-0.1f));
		}
		if (Input.GetKey ("a")) {
			camera.Translate(new Vector3(-0.1f,0));
		}
		if (Input.GetKey ("d")) {
			camera.Translate(new Vector3(0.1f,0));
		}
	}
}
