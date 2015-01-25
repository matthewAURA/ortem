using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Grid grid;
	public Road road;
	public Home homeTemplate;
	public Work work;
	public Car car;

	public static float GameTickLength = 0.1f;

	private List<Car> cars = new List<Car>();

	// Use this for initialization
	void Start () {
		StartCoroutine (Timing());

	}
	
	// Update is called once per frame
	void Update () {
	}

	private Home getRandomHome() {
		if (grid.homes.Count > 0) {
			return grid.homes [Random.Range (0, grid.homes.Count)];
		} else {
			return null;
		}
	}

	private Work getRandomWork() {
		if (grid.works.Count > 0) {
			return grid.works [Random.Range (0, grid.works.Count)];
		}else{
			return null;
		}
	}

	IEnumerator Timing() {
		while (true) {
			yield return new WaitForSeconds (GameTickLength);
			foreach (Home h in grid.homes) {
				if (Random.Range(0,1.0f) > 0.9){
					Work w = getRandomWork();
					if (h != null && w != null){
						var newCar = h.createCar(w.position); 
						cars.Add (newCar);
					}
				}
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
		switch (b) {
		case BuildAction.BUILD_ROAD:
			createPlaceable (road, p);
			break;
		case BuildAction.BUILD_HOME:
			createPlaceable(homeTemplate,p);
			break;
		case BuildAction.BUILD_WORK:
			createPlaceable(work,p);
			break;
		case BuildAction.DELETE:
			grid.removePlaceable(p);
			break;
		}

	}

	public Placeable createPlaceable(Placeable thing, Point p){
		if (grid.getAt (p) == null) {

			var newT = (Placeable)Instantiate (thing);
			grid.placePlaceable (newT, p);
			return newT;
		}
		return null;
	}

}
