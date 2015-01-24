using UnityEngine;
using System;

public class GridGraph : MonoBehaviour
{
	public Grid grid;
	private bool isGridDirty = true;

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
			//if (grid.getAt(Point prop) instanceof Road)
		}
	}

}


