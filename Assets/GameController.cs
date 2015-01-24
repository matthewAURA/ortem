using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public Grid grid;
	public Road road;
	public Home home;
	public Work work;
	public Car car;

	// Use this for initialization
	void Start () {
		StartCoroutine (Timing());
		for (int i = 1; i < 9; i++)
		{
			create(road, new Point(i,1));
		}
		create(home, new Point (0, 1));
		create(work, new Point (9, 1));
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
					var newCar = (Car)this.create(car, new Point(0,1));
					newCar.home = new Point(0,1);
					newCar.work = new Point(9,1);
				}
			}
			foreach(var car in grid.cars){
				car.drive();
			}
		}
	}

	public Placeable create(Placeable thing, Point p){
		var newT = (Placeable)Instantiate (thing);
		grid.placePlaceable(newT,p);
		return newT;
	}
}
