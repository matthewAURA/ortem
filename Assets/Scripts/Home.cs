using UnityEngine;
using System.Collections;

public class Home : Placeable
{


	public Car car;

	// Use this for initialization
	public override void Start (){
		base.Start ();
		
	}
	
	// Update is called once per frame
	public override void Update () {
		
	}

	public Car createCar(Point p){
		var newCar = (Car)Instantiate (car);
		newCar.position = this.position;
		newCar.home = this.position;
		newCar.work = p;
		newCar.transform.position = Grid.getGrid().moveToWorldCoordinates (position);

		return newCar;
	}
}


