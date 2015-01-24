using UnityEngine;
using System.Collections;

public class Placeable : MonoBehaviour {



	public Point position;

	// Use this for initialization
	public virtual void Start () {
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

	public void moveToPostion(Vector3 position){
		((Transform)this.GetComponent ("Transform")).position = position;
	}


	

	
}
