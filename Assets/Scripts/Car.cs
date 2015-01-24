using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Car : MonoBehaviour
{

	public Point home;
	public Point work;
	public GridGraph graph;
	public Direction direction { get; private set; }
	private IList<Direction> turns;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}



}
