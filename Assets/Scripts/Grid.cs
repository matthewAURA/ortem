using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour
{

	public  int width;
	public  int height;
	public  int gridSize;

	public GridSquare gridSquare;

	private Placeable[,] grid;


	// Use this for initialization
	void Start () {
		grid = new Placeable[width,height];
		//Render all the grid Square
		for (int i=0; i<grid.GetLength(0); i++) {
			for (int j=0;j<grid.GetLength(1);j++){
				GridSquare square = (GridSquare)Instantiate(gridSquare);
				((Transform)square.GetComponent("Transform")).position = new Vector3(i*gridSize,-j*gridSize,0);
				square.gridIndex = new Point(i,j);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}

	public Placeable getAt(Point p){
		return this.grid[p.x,p.y];
	}

	public void updateGrid(Point p){

	}
}
