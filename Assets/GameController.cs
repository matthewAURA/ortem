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

	IEnumerator Timing() {
		while (true) {
			yield return new WaitForSeconds (0.1f);
			if (Random.Range(0,1.0f) > 0.7){
				var newCar = home.createCar(new Point(9,1)); 
				cars.Add (newCar);
			}
			List<Car> toRemove = new List<Car>();
			foreach(Car carIter in cars){
				Car.DriveState result = carIter.drive();
				if (result == Car.DriveState.AT_DESTINATION) {
					toRemove.Add(carIter);
				}
			}
			foreach (Car carIter in toRemove) {
				cars.Remove(carIter);
				Destroy (carIter.gameObject);
			}

		}
	}

	public Placeable createPlaceable(Placeable thing, Point p){
		var newT = (Placeable)Instantiate (thing);
		grid.placePlaceable(newT,p);
		return newT;
	}

}
