using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour
{
	private static Grid staticGrid;

	public static Grid getGrid()
	{
		return staticGrid;
	}

	public  int width;
	public  int height;
	public  int gridSize;

	public GridSquare gridSquare;

	private Placeable[,] placeableGrid;
	private RoadLogic[,] roadGrid;

	public Dictionary<Placeable,Point> placeables = new Dictionary<Placeable,Point>();
	public List<Home> homes = new List<Home>();
	public List<Work> works = new List<Work>();
	public int numChanges  {get; private set;}

	void Awake ()
	{
		staticGrid = this;
		placeableGrid = new Placeable[width,height];
		roadGrid = new RoadLogic[width, height];
		for (int i=0; i<width; i++) {
			for (int j=0; j<height; j++){
				roadGrid[i,j] = new RoadLogic();
			}
		}
		numChanges = 0;
	}

	// Use this for initialization
	void Start () {
		//Render all the grid Square
		for (int i=0; i<placeableGrid.GetLength(0); i++) {
			for (int j=0;j<placeableGrid.GetLength(1);j++){
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
		return placeableGrid[p.x,p.y];
	}


	public bool placePlaceable(Placeable placeable,Point p){
		numChanges++;
		if (placeableGrid [p.x, p.y] == null) {
			placeableGrid [p.x, p.y] = placeable;
			placeables [placeable] = p;
			if (placeable is Home) {
				homes.Add((Home)placeable);
			} else if (placeable is Work) {
				works.Add((Work)placeable);
			}
			placeable.position = p;
			placeable.moveToPostion (moveToWorldCoordinates (p));
			return true;
		}else{
			return false;
		}
	}

	public bool removePlaceable(Point p){
		numChanges++;
		var oldPlaceable = placeableGrid [p.x, p.y];
		if (oldPlaceable != null) {
			placeableGrid [p.x, p.y] = null;
			placeables.Remove (oldPlaceable);
			if (oldPlaceable is Home) {
				homes.Remove((Home)oldPlaceable);
			} else if (oldPlaceable is Work) {
				works.Remove((Work)oldPlaceable);
			}
			Destroy (oldPlaceable.gameObject);
		}
		return false;
	}

	public Vector3 moveToWorldCoordinates(Point p){
		return new Vector3 (p.x * gridSize, -p.y * gridSize, 0);
	}

	public RoadLogic getRoadAt(Point p) {
		return roadGrid [p.x, p.y];
	}

}
