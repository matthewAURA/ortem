using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public  int width;
	public  int height;
	public  int gridSize;

	public Transform gridSquare;

	private Placeable[,] grid;


	// Use this for initialization
	void Start () {
		grid = new Placeable[width,height];
		//Render all the grid Square
		for (int i=0; i<grid.GetLength(0); i++) {
			for (int j=0;j<grid.GetLength(1);j++){
				Transform square = (Transform)Instantiate(gridSquare);
				square.position = new Vector3(i*gridSize,j*gridSize,0);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	private Vector2 convertPositonToGrid(int xPixel,int yPixel){
		//Horizontal
		int xSquare = xPixel / gridSize;
		int ySquare = yPixel / gridSize;

		if (!(grid[xSquare, ySquare] == null)){
			grid[xSquare,ySquare] = p;
		}
	}


}
