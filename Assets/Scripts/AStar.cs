using UnityEngine;
using System;

/**
 * 
 */
using System.Collections.Generic;


public class AStar
{

	public List<Point> getPath(Point source, Point target)
	{
		Debug.Log ("getPath called: " + source + " to " + target);
		PriorityQueue<int,Point> pq = new PriorityQueue<int,Point> ();
		Dictionary<Point, int> bestDists = new Dictionary<Point, int> ();
		bestDists [target] = int.MaxValue;
		bestDists [source] = 0;
		pq.Enqueue (0 + heuristicDist(source, target), source);
		while (pq.Count > 0)
		{
			Point p = pq.DequeueValue();
			Debug.Log("A* exploring " + p);
			int d = bestDists[p];
			if (d-1 > bestDists[target]) // maybe -1 or something?
			{
				break;
			}
			int h = heuristicDist(p, target);
			if (h == 1)
			{
				// Success, we can drive on target even if it's not a road
				bestDists[target] = Math.Min(bestDists[target], d+1);
				continue;
			}
			foreach (Point neighbour in getNeighboursOfType<Road>(p))
			{
				if (!bestDists.ContainsKey(neighbour))
				{
					bestDists[neighbour] = int.MaxValue;
				}
				if (d + 1 < bestDists[neighbour])
				{
					bestDists[neighbour] = d + 1;
					pq.Enqueue(d + 1 + heuristicDist(neighbour, target), neighbour);
				}
			}
		}
		if (bestDists [target] == int.MaxValue)
		{
			return null;
		}
		Point current = target;
		List<Point> path = new List<Point>();
		List<Point> possibleNext = new List<Point>(4);
		while (current.Equals(source))
		{
			path.Add(current);
			possibleNext.Clear();
			foreach (Point n in current.getNeighbours())
			{
				if (bestDists.ContainsKey(n) && bestDists[n] == bestDists[current] - 1)
				{
					possibleNext.Add(n);
				}
			}
			int randomIndex = UnityEngine.Random.Range(0, possibleNext.Count);
			current = possibleNext[randomIndex];
		}
		path.Add (source);
		path.Reverse ();
		return path;
	}

	int heuristicDist(Point s, Point t)
	{
		return Math.Abs (s.x - t.x) + Math.Abs (s.y - t.y);
	}


	private List<Point> getNeighboursOfType<T>(Point p)
	{
		List<Point> neighboursOfType = new List<Point>();
		foreach (Point n in p.getNeighbours())
		{
			if (Grid.getGrid().getAt(n) is T)
			{
				neighboursOfType.Add(n);
			}
		}
		return neighboursOfType;
	}
	
}


