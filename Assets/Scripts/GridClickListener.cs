using UnityEngine;
using System.Collections;

public class GridClickListener : MonoBehaviour {

	public Grid grid;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Debug.Log (Input.mousePosition);
	}
}
