﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
	public static HashSet<Car> waitingCars = new HashSet<Car> (); // Doesn't work!

	public Point home;
	public Point work;
	public AStar navigator = new AStar ();
	public Direction direction { get; private set; }
	public Point position;
	public CarPosOnRoad posOnRoad;

	private IList<Direction> turns;
	private List<Point> path;
	private int positionInPath = 0;
	private int numChangesForValidPath = -1;

	private Vector3 oldLocation;
	private Vector3 newLocation;

	private int numTicks = 100;
	private int tickRate = 10;
	private int tickPos = 0;

	public struct CarPosOnRoad {
		public Direction at;
		public Direction headed;
		public bool front;
		public bool initial; // initial pos can overlap other cars, so don't remove whatever else might be there
	}

	void Awake(){
		posOnRoad = new CarPosOnRoad();
		posOnRoad.at = (Direction)Random.Range(0, 4);
		posOnRoad.headed = posOnRoad.at.opposite();
		posOnRoad.front = true;
		posOnRoad.initial = true;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		float fracMoved = (float)tickPos / (float)numTicks;
		tickPos += tickRate;
		if (fracMoved > 1) {
			transform.position = this.newLocation;
		} else {
			transform.position = Vector3.Lerp (this.oldLocation, this.newLocation, fracMoved);
		}
	}

	public void moveToPoint(Point p, CarPosOnRoad por){
		//TODO pos on road
		Vector3 d = new Vector3 (0, 0, -1);
		d += Grid.getGrid().moveToWorldCoordinates(p);
		if (por.at == Direction.NORTH) {
			((Transform)this.GetComponent ("Transform")).rotation = Quaternion.AngleAxis (90, new Vector3 (0, 0, 1));
			d += new Vector3(0,0.3f);
		}
		if (por.at == Direction.SOUTH) {
			d += new Vector3(0,-0.3f);
			((Transform)this.GetComponent ("Transform")).rotation = Quaternion.AngleAxis (90, new Vector3 (0, 0, 1));
		}
		if (por.at == Direction.EAST) {
			d += new Vector3(0.3f,0);
			((Transform)this.GetComponent ("Transform")).rotation = Quaternion.AngleAxis (0, new Vector3 (0, 0, 1));
		}
		
		if (por.at == Direction.WEST) {
			d += new Vector3(-0.3f,0);
			((Transform)this.GetComponent ("Transform")).rotation = Quaternion.AngleAxis (0, new Vector3 (0, 0, 1));

		}

		if (por.headed == Direction.NORTH) {
			if(por.front){
				d+= new Vector3(0,0.1f);
			}else{
				d+= new Vector3(0,-0.1f);
			}
			d += new Vector3(-0.1f,0f);
		}
		if (por.headed == Direction.SOUTH) {
			if(por.front){
				d+= new Vector3(0,-0.1f);
			}else{
				d+= new Vector3(0,0.1f);
			}
			d += new Vector3(0.1f,0f);
		}
		if (por.headed == Direction.EAST) {
			if(por.front){
				d+= new Vector3(0.1f,0);
			}else{
				d+= new Vector3(-0.1f,0);
			}
			d += new Vector3(0,0.1f);
		}
		
		if (por.headed == Direction.WEST) {
			if(por.front){
				d+= new Vector3(-0.1f,0);
			}else{
				d+= new Vector3(0.1f,0);
			}
			d += new Vector3(0,-0.1f);
		}

		this.oldLocation = transform.position;
		this.newLocation = d;
		this.tickPos = 0;

		//this.transform.position = d;



	}


	public void moveToPoint(Point p) { // for initial position (place somewhere randomly on the tile?)
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
		// Actually DRIVE
		DriveState subState = subDrive ();
		if (subState == DriveState.MOVED_TILE ) {
			positionInPath++;
			position = path [positionInPath];
		}
		if (subState == DriveState.MOVED_TILE || subState == DriveState.MOVED) {
			posOnRoad.initial = false;
			moveToPoint(position, posOnRoad);
		}
		return subState;
	}

	public enum DriveState {
		MOVED, MOVED_TILE, STOPPED, AT_DESTINATION, CANNOT_REACH_DESTINATION
	}

	private DriveState subDrive() {

		Point nextPosition = path [positionInPath + 1];
		Direction at = posOnRoad.at;
		Direction headed = posOnRoad.headed;
		bool front = posOnRoad.front;
		RoadLogic rl = Grid.getGrid().getRoadAt(position);
		if (!front) { // not at front. try move to front
			if (rl.getCar (at, headed, true) == null) {
				rl.setCar (posOnRoad, null);
				posOnRoad.front = true;
				rl.setCar (posOnRoad, this);
				return DriveState.MOVED;
			} else {
				return DriveState.STOPPED;
			}
		} else if (at == headed) { // at outer edge. try to move to next tile
			RoadLogic rlNext = Grid.getGrid ().getRoadAt (nextPosition);
			Direction atNext = at.opposite ();
			if (rlNext.getCar (atNext, headed, false) == null) {
				rl.setCar (posOnRoad, null);
				posOnRoad.at = atNext;
				posOnRoad.front = false;
				rlNext.setCar (posOnRoad, this);
				return DriveState.MOVED_TILE;
			} else {
				return DriveState.STOPPED;
			}
		} else { // needs to cross the intersection
			Direction dir = position.getDirectionOf(nextPosition);
			if (rl.getCar(dir, dir, false) == null) {
				rl.setCar (posOnRoad, null);
				posOnRoad.at = dir;
				posOnRoad.headed = dir;
				posOnRoad.front = false;
				rl.setCar(posOnRoad, this);
				return DriveState.MOVED;
			} else {
				return DriveState.STOPPED;
			}
		}
	}



}
