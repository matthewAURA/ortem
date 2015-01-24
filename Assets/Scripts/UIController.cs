using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	
	public static BuildAction CurrentBuildAction = BuildAction.BUILD_ROAD;
	public BuildAction onClickBuildAction;
	public Transform camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	
	void OnMouseUp(){
		CurrentBuildAction = onClickBuildAction;	
	}
}
