using UnityEngine;
using System.Collections;

public class FixedGUI : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture houseTexture;
	public Texture factoryTexture;
	public Texture roadTexture;
	public float scaleFactor = 0.1f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if (!backgroundTexture) {
			Debug.Log ("No texture");
		} else {
			for (int i=1;i<4;i++){
				GUI.DrawTexture (new Rect (0,Screen.height-(i*backgroundTexture.height*scaleFactor),backgroundTexture.width*scaleFactor, backgroundTexture.height*scaleFactor), backgroundTexture, ScaleMode.StretchToFill, true, 1.0f);
			}
			//This line isn't complicated enough...
			if (GUI.Button(new Rect((backgroundTexture.width-houseTexture.width)*0.5f*scaleFactor,
			                    Screen.height-(backgroundTexture.height*scaleFactor)+(backgroundTexture.height-houseTexture.height)*0.5f*scaleFactor,
			                    houseTexture.width*scaleFactor,
			                    houseTexture.height*scaleFactor),
			           houseTexture)){
				UIController.CurrentBuildAction = BuildAction.BUILD_HOME;
			}

			if (GUI.Button(new Rect((backgroundTexture.width-factoryTexture.width)*0.5f*scaleFactor,
			                    Screen.height-(backgroundTexture.height*scaleFactor*2)+(backgroundTexture.height-factoryTexture.height)*0.5f*scaleFactor,
			                    factoryTexture.width*scaleFactor,
			                    factoryTexture.height*scaleFactor),
			           factoryTexture)){
				
				UIController.CurrentBuildAction = BuildAction.BUILD_WORK;
			}

			if (GUI.Button(new Rect((backgroundTexture.width-roadTexture.width)*0.5f*scaleFactor,
			                    Screen.height-(backgroundTexture.height*scaleFactor*3)+(backgroundTexture.height-roadTexture.height)*0.5f*scaleFactor,
			                    roadTexture.width*scaleFactor,
			                    roadTexture.height*scaleFactor),
			           roadTexture)){
				UIController.CurrentBuildAction = BuildAction.BUILD_ROAD;
			}
		} 	
	}

}
