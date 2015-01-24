using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : Placeable
{

	public Point home;
	public Point work;
	public AStar graph;
	public Direction direction { get; private set; }
	private IList<Direction> turns;

	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		base.Update ();
	}



}
