using UnityEngine;
using System.Collections;
using System;

public class Road : Placeable
{

	public Sprite roadStraight;
	public Sprite roadCross;
	public Sprite roadThree;
	public Sprite roadCorner;

	private Sprite activeSprite;

	// Use this for initialization
	public override void Start (){
		base.Start ();
		activeSprite = roadCross;

	}
	
	// Update is called once per frame
	public override void Update () {
		updateSprite ();
	}

	public void updateSprite(){
		//Work out how many roads are around us.
		Point thisPosition;
		try{
			thisPosition = Grid.getGrid ().placeables [this];
		}catch (Exception e){
			return;
		}
		int numRoads = 0;
		foreach (var p in thisPosition.getNeighboursOfType<Road>()){
			if (Grid.getGrid().getAt(p) is Road){
				numRoads++;
			}
		}
		int facingDirection = 0;
		//Possibly the worst code I have ever written
		switch (numRoads) {
		case 0: case 4:
			activeSprite = roadCross;
			break;
		case 3:
			foreach (Direction n in Enum.GetValues(typeof(Direction))){
				if (thisPosition.getPlaceableNeighbour(n) == null || !(thisPosition.getPlaceableNeighbour(n) is Road)){
					facingDirection = (int)n;
				}
			}
			activeSprite = roadThree;
			break;
		case 1 : 
			activeSprite = roadStraight;
			foreach (Direction n in Enum.GetValues(typeof(Direction))){
				if (thisPosition.getPlaceableNeighbour(n) != null && thisPosition.getPlaceableNeighbour(n) is Road){
					facingDirection = ((int)n) + 1;
					break;
				}
			}
			break;
		case 2:
			activeSprite = roadStraight;
			if (thisPosition.getPlaceableNeighbour(Direction.NORTH) != null &&
			    thisPosition.getPlaceableNeighbour(Direction.SOUTH) != null &&
			    (thisPosition.getPlaceableNeighbour(Direction.NORTH) is Road && thisPosition.getPlaceableNeighbour(Direction.SOUTH) is Road)){
				facingDirection = (int)Direction.EAST;
			}else if (thisPosition.getPlaceableNeighbour(Direction.EAST) != null &&
			          thisPosition.getPlaceableNeighbour(Direction.WEST) != null && 
			          (thisPosition.getPlaceableNeighbour(Direction.EAST) is Road &&
			 thisPosition.getPlaceableNeighbour(Direction.WEST) is Road)){
				facingDirection = (int)Direction.NORTH;	
			}else{
				//Corner Case
				activeSprite = roadCorner;
				if (thisPosition.getPlaceableNeighbour(Direction.NORTH) != null && thisPosition.getPlaceableNeighbour(Direction.NORTH) is Road){
					if (thisPosition.getPlaceableNeighbour(Direction.EAST) != null && thisPosition.getPlaceableNeighbour(Direction.EAST) is Road){
						facingDirection = 3;
					}else{
						facingDirection = 2;
					}
				}else{
					if (thisPosition.getPlaceableNeighbour(Direction.EAST) != null && thisPosition.getPlaceableNeighbour(Direction.EAST) is Road){
						facingDirection = 0;
					}else{
						facingDirection = 1;
					}
				}

			}

			break;
		}
	
		((SpriteRenderer)this.GetComponent ("SpriteRenderer")).sprite = activeSprite;
		((Transform)this.GetComponent ("Transform")).rotation = Quaternion.AngleAxis (-facingDirection * 90 + 180, new Vector3 (0, 0, 1));
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


