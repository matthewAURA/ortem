using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Grid grid;
	public Road road;
	public Home homeTemplate;
	public Home home;
	public Work work;
	public Car car;

	private List<Car> cars = new List<Car>();

	// Use this for initialization
	void Start () {
		StartCoroutine (Timing());
		for (int i = 1; i < 8; i++)
		{
			createPlaceable(road, new Point(i,1));
			createPlaceable(road, new Point(i,3));
		}
		createPlaceable(road, new Point(0,2));
		createPlaceable(road, new Point(0,3));
		createPlaceable(road, new Point(9,2));
		createPlaceable(road, new Point(9,3));
		createPlaceable(road, new Point(8,3));
		home = (Home)createPlaceable(homeTemplate, new Point (0, 1));
		createPlaceable(work, new Point (9, 1));
	}
	
	// Update is called once per frame
	void Update () {
	}

	private Home getRandomHome() {
		return grid.homes [Random.Range (0, grid.homes.Count)];
	}

	private Work getRandomWork() {
		return grid.works [Random.Range (0, grid.works.Count)];
	}

	IEnumerator Timing() {
		while (true) {
			yield return new WaitForSeconds (0.1f);
			if (Random.Range(0,1.0f) > 0.7){

				Home h = getRandomHome();
				Work w = getRandomWork();
				var newCar = h.createCar(w.position); 
				cars.Add (newCar);
			}

			for (int i = cars.Count - 1; i >= 0; i--) { // reverse iteration so we can remove safely
				Car.DriveState result = cars[i].drive();
				if (result == Car.DriveState.AT_DESTINATION) {
					Destroy (cars[i].gameObject);
					cars.RemoveAt(i);
				}
			}
		}
	}

	
	public void updateGrid(BuildAction b,Point p){
		Debug.Log ("update");
		switch (b) {
		case BuildAction.BUILD_ROAD:
			createPlaceable (road, p);
			break;
		case BuildAction.DELETE:
			removePlaceable(p);
			break;
		}

	}

	public Placeable createPlaceable(Placeable thing, Point p){
		var newT = (Placeable)Instantiate (thing);
		grid.placePlaceable(newT,p);
		return newT;
	}

	public void removePlaceable(Point p){
		Debug.Log ("remove");
		grid.removePlaceable (p);
	}

}
