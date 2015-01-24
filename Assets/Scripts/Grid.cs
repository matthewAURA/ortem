using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{

	public  int width;
	public  int height;
	public  int gridSize;

	public GridSquare gridSquare;

	private Placeable[,] grid;

	public List<Road> roads = new List<Road>();
	public List<Home> homes = new List<Home>();
	public List<Work> works = new List<Work>();
	public List<Car> cars = new List<Car>();

	void Awake ()
	{
		grid = new Placeable[width,height];
	}

	// Use this for initialization
	void Start () {
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

	public bool placePlaceable(Placeable placeable,Point p){
			this.grid[p.x,p.y] = placeable;
			if (placeable is Car) {
				cars.Add((Car)placeable);
			} else if (placeable is Home) {
				homes.Add((Home)placeable);
			} else if (placeable is Work) {
				works.Add ((Work)placeable);
			} else if (placeable is Road) {
				roads.Add ((Road)placeable);
			}
			placeable.moveToPostion(new Vector3(p.x*gridSize,-p.y*gridSize,0));
			return true;
	}

	public void renderCarOnGrid(Car car,Point p){
		if (this.getAt (p) != null) {
			var placeable = this.getAt(p);
			if (placeable is Road){
				((Road)placeable).moveCar(car);
			}
		}
	}




}
