using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public  int width;
	public  int height;
	public  int gridSize;

	private Placeable[,] grid;
	// Use this for initialization
	void Start () {
		grid = new Placeable[width,height];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void placeObject(Placeable p,int xPixel,int yPixel){
		//Horizontal
		int xSquare = xPixel / gridSize;
		int ySquare = yPixel / gridSize;

		if (!(grid[xSquare, ySquare] == null)){
			grid[xSquare,ySquare] = p;
		}
	}


}
