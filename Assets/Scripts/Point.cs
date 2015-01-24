
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

	/** 
	 * Get neighbours (not diagonal) inside the grid
	 */
	public List<Point> getNeighbours(Grid grid)
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
		if (x < grid.width - 1)
		{
			neighbours.Add(new Point(x + 1, y));
		}
		if (y < grid.height - 1)
		{
			neighbours.Add(new Point(x, y + 1));
		}
		return neighbours;
	}
}


