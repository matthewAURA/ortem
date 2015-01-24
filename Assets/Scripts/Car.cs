using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{

	public Point home;
	public Point work;
	public AStar navigator = new AStar ();
	public Direction direction { get; private set; }
	public Point position;
	private IList<Direction> turns;
	private List<Point> path;
	private int positionInPath = 0;
	private int numChangesForValidPath = -1;

	void Awake(){

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
		if (numChangesForValidPath < Grid.getGrid().numChanges) {
			// refresh path
			path = navigator.getPath (position, work);
			numChangesForValidPath = Grid.getGrid().numChanges;
			positionInPath = 0;
		}
		if (path == null) {
			return DriveState.CANNOT_REACH_DESTINATION;
		}
		if (path.Count > positionInPath) {
			positionInPath++;
			this.position = path [positionInPath];
			moveToPoint(this.position);
			return DriveState.DRIVING;
		}
		Debug.Log ("should never happen!?! path.count is " + path.Count);
		return DriveState.WHO_KNOWS;
	}

	public enum DriveState {
		DRIVING, AT_DESTINATION, CANNOT_REACH_DESTINATION, WHO_KNOWS
	}


}
