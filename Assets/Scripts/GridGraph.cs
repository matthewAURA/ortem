using UnityEngine;
using System;

/**
 * 
 */
using System.Collections.Generic;


public class GridGraph : MonoBehaviour
{
	public Grid grid;
	private bool isGridDirty = true;
	// private Dictionary<Point, List<Edge>> graph = new Dictionary();

	public void gridUpdated()
	{
		isGridDirty = true;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (isGridDirty)
		{

			// update grid graph
			for (int y = 0; y < grid.height; y++)
			{
				for (int x = 0; x < grid.width; x++)
				{

				}
			}
			//if (grid.getAt(Point prop) instanceof Road)
		}
	}

//	private List<Edge> getEdges(Point p)
//	{
//		if (isGridDirty)
//		{
//			this.Update();
//		}
//		return graph [p];
//	}
//
//	private struct Edge
//	{
//		Point p;
//		int distance;
//	}

	public IList<Direction> getPath(Point source, Point target)
	{
		// grid.
		return null;
		//source.
		//for (int x = source.x
	}
	
}


