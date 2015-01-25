
using System;


public enum Direction
{
	NORTH = 0,
	EAST = 1,
	SOUTH = 2,
	WEST = 3,

}

static class DirectionMethods {
	public static Direction opposite(this Direction d) {
		return (Direction)(((int)d + 2) % 4);
	}
}


