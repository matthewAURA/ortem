using UnityEngine;
using System.Collections;

public class GridSquare : MonoBehaviour {

	public Point gridIndex { get; set; }
	public GameController gameController;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver(){
		Debug.Log ("Mouse");
		if (Input.GetMouseButtonDown(0)){
			gameController.updateGrid(BuildAction.BUILD_ROAD,this.gridIndex);
		}else if (Input.GetMouseButtonDown(1)){
			gameController.updateGrid(BuildAction.DELETE,this.gridIndex);
		}

	}

	void OnMouseUp(){

	}
}
