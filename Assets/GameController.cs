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
		for (int i = 1; i < 9; i++)
		{
			createPlaceable(road, new Point(i,1));
		}
		home = (Home)createPlaceable(homeTemplate, new Point (0, 1));
		createPlaceable(work, new Point (9, 1));
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Timing() {
		while (true) {
			yield return new WaitForSeconds (2);
			if (Random.Range(0,1.0f) > 0){
				var newCar = home.createCar(new Point(9,1)); 

				cars.Add (newCar);
			}
			foreach(var carIter in cars){
				carIter.drive();
			}

		}
	}

	public Placeable createPlaceable(Placeable thing, Point p){
		var newT = (Placeable)Instantiate (thing);
		grid.placePlaceable(newT,p);
		return newT;
	}

}
