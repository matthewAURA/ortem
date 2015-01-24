using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{

	public Point home;
	public Point work;
	public AStar navigator;
	public Direction direction { get; private set; }
	public Point position;
	private IList<Direction> turns;

	void Awake(){
		navigator = new AStar ();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void moveToPoint(Point p){
		this.transform.position = Grid.getGrid().moveToWorldCoordinates(p);
	}

	public void drive(){
		var path = navigator.getPath (position, work);
		if (path.Count > 1) {
			this.position = path [1];
			moveToPoint(this.position);
		}
	}


}
