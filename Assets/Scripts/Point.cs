
using System;
using System.Collections.Generic;

public struct Point
{
	public int x;
	public int y;

	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override bool Equals(object o)
	{
		if (o is Point)
		{
			Point p = (Point)o;
			return x == p.x && y == p.y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (x * 31 * 31) ^ y;
	}

	public override string ToString ()
	{
		return string.Format ("[Point {0} {1}]", x, y);
	}

	/** 
	 * Get neighbours (not diagonal) inside the grid
	 */
	public List<Point> getNeighbours()
	{
		List<Point> neighbours = new List<Point>();
		
		if (x > 0)
		{
			neighbours.Add(new Point(x - 1, y));
		}
		if (y > 0)
		{
			neighbours.Add(new Point(x, y - 1));
		}
		if (x < Grid.getGrid().width - 1)
		{
			neighbours.Add(new Point(x + 1, y));
		}
		if (y < Grid.getGrid().height - 1)
		{
			neighbours.Add(new Point(x, y + 1));
		}
		return neighbours;
	}

	public List<Point> getNeighboursOfType<T>()
	{
		List<Point> neighboursOfType = new List<Point>();
		foreach (Point n in this.getNeighbours())
		{
			if (Grid.getGrid().getAt(n) is T)
			{
				neighboursOfType.Add(n);
			}
		}
		return neighboursOfType;
	}

	public Point getDirection(Direction direction){
		switch (direction) {
		case Direction.WEST:
			if (x > 0) {
				return new Point (x - 1, y);
			}
			break;
		case Direction.EAST:
			if (x < Grid.getGrid().width - 1){
				return new Point (x + 1, y);
			}
			break;
		case Direction.SOUTH:
			if (y < Grid.getGrid().height - 1){
				return new Point (x, y + 1);
			}
			break;
		case Direction.NORTH:
			if (y > 0) {
				return new Point (x, y - 1);
			}
			break;
		}
		throw new Exception("Point out of Range");
	}

	public Placeable getPlaceableNeighbour(Direction direction){
		Point p;
		try{
			p = getDirection(direction);
		}catch (Exception e){
			return null;
		}

		return Grid.getGrid().getAt(p);
	}

}


