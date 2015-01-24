using UnityEngine;
using System.Collections;

public class Road : Placeable
{
	// Use this for initialization
	public override void Start (){
		base.Start ();

	}
	
	// Update is called once per frame
	public override void Update () {
		
	}

	public void moveCar(Car car){
		car.transform.parent = this.transform;
		switch (car.direction) {
		case Direction.NORTH:
			car.transform.localPosition = new Vector3(-0.1f,0.4f,-1f);
			break;
		case Direction.EAST:
			car.transform.localPosition = new Vector3(0.4f,0.1f,-1f);
			break;
		case Direction.SOUTH:
			car.transform.localPosition = new Vector3(0.1f,-0.4f,-1f);
			break;
		case Direction.WEST:
			car.transform.localPosition = new Vector3(-0.4f,-0.1f,-1f);
			break;
		}
	}

}


