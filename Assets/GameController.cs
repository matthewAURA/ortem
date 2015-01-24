using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public Grid grid;
	public Road road;
	public Home home;
	public Work work;

	// Use this for initialization
	void Start () {
		//StartCoroutine (Timing());
		for (int i = 1; i < 9; i++)
		{
			createRoad(new Point(i,1));
		}
		createHouse (new Point (0, 1));
		createWork (new Point (9, 1));
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Timing() {
		while (true) {
			yield return new WaitForSeconds (2);
			if (Random.Range(0,1.0f) > 0.5){
				int xPos = Random.Range (0,10);
				int yPos = Random.Range (0,10);
				if (grid.getAt(new Point(xPos,yPos)) == null){
					this.createHouse(new Point(xPos,yPos));
				}
			}
		}
	}


	public Placeable createRoad(Point p){
		var newRoad = (Road)Instantiate (road);
		grid.placePlaceable(newRoad,p);
		return newRoad;
	}
	
	public Placeable createHouse(Point p){
		var newHouse = (Home)Instantiate (home);
		grid.placePlaceable (newHouse, p);
		return newHouse;
	}
	public Placeable createWork(Point p){
		var newWork = (Work)Instantiate (work);
		grid.placePlaceable (newWork, p);
		return newWork;
	}

}
