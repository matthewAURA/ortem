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
		Debug.Log (UIController.CurrentBuildAction);
		if (Input.GetMouseButton(0)){
			gameController.updateGrid(UIController.CurrentBuildAction,this.gridIndex);
		}else if (Input.GetMouseButton(1)){
			gameController.updateGrid(BuildAction.DELETE,this.gridIndex);
		}

	}

	void OnMouseUp(){

	}
}
