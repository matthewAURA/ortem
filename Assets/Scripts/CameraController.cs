using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform camera;
	public float scrollSpeed = 0.2f;
	public float edgeScrollPercent = 0.01f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.mousePosition.x < Screen.width * edgeScrollPercent) {
			camera.Translate(new Vector3(-scrollSpeed,0f));
		}
		if (Input.mousePosition.x > Screen.width * 1-(edgeScrollPercent)) {
			camera.Translate(new Vector3(scrollSpeed,0f));
		}
		if (Input.mousePosition.y < Screen.height * edgeScrollPercent) {
			camera.Translate(new Vector3(0f,-scrollSpeed));
		}
		if (Input.mousePosition.y > Screen.height *(1-edgeScrollPercent)) {
			camera.Translate(new Vector3(0f,scrollSpeed));
		}


		if (Input.GetKey ("w")) {
			camera.Translate(new Vector3(0,scrollSpeed));
		}
		if (Input.GetKey ("s")) {
			camera.Translate(new Vector3(0,-scrollSpeed));
		}
		if (Input.GetKey ("a")) {
			camera.Translate(new Vector3(-scrollSpeed,0));
		}
		if (Input.GetKey ("d")) {
			camera.Translate(new Vector3(scrollSpeed,0));
		}
	}
}
