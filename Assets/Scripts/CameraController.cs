using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform cameraTrans;
	public float scrollSpeed = 0.2f;
	public float edgeScrollPercent = 0.01f;
	public bool edgeScroll = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (edgeScroll) {
			if (Input.mousePosition.x < Screen.width * edgeScrollPercent) {
				cameraTrans.Translate (new Vector3 (-scrollSpeed, 0f));
			}
			if (Input.mousePosition.x > Screen.width * 1 - (edgeScrollPercent)) {
				cameraTrans.Translate (new Vector3 (scrollSpeed, 0f));
			}
			if (Input.mousePosition.y < Screen.height * edgeScrollPercent) {
				cameraTrans.Translate (new Vector3 (0f, -scrollSpeed));
			}
			if (Input.mousePosition.y > Screen.height * (1 - edgeScrollPercent)) {
				cameraTrans.Translate (new Vector3 (0f, scrollSpeed));
			}
		}


		if (Input.GetKey ("w")) {
			cameraTrans.Translate(new Vector3(0,scrollSpeed));
		}
		if (Input.GetKey ("s")) {
			cameraTrans.Translate(new Vector3(0,-scrollSpeed));
		}
		if (Input.GetKey ("a")) {
			cameraTrans.Translate(new Vector3(-scrollSpeed,0));
		}
		if (Input.GetKey ("d")) {
			cameraTrans.Translate(new Vector3(scrollSpeed,0));
		}
	}
}
