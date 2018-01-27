using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugScript : MonoBehaviour 
{
	public bool isGrabbed = false;

	private bool beenGrabbed = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}


	public void GrabFinished()
	{
		// check to see if we are colliding with the plug insert
		// if colliding then set insert as parent and take position and rotation
		// else have cord go back to the board 
		Debug.Log("We are trying to connect the plug");
	}
}
