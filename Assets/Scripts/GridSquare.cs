﻿using UnityEngine;
using System.Collections;

public class GridSquare : MonoBehaviour {

	public Grid grid;
	public Point gridIndex { get; set; }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		Debug.Log (gridIndex.x);
	}

	void OnMouseUp(){
		grid.updateGrid (this.gridIndex);
	}
}
