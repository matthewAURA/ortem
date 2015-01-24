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

	public DriveState drive(){
		if (position.Equals (work)) {
			return DriveState.AT_DESTINATION;
		}
		var path = navigator.getPath (position, work);
		if (path == null) {
			return DriveState.CANNOT_REACH_DESTINATION;
		}
		if (path.Count > 1) {
			this.position = path [1];
			moveToPoint(this.position);
			return DriveState.DRIVING;
		}
		Debug.Log ("weird case? path.count is " + path.Count);
		return DriveState.WHO_KNOWS;
	}

	public enum DriveState {
		DRIVING, AT_DESTINATION, CANNOT_REACH_DESTINATION, WHO_KNOWS
	}


}
