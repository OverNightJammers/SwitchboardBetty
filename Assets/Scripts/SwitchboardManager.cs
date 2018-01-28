using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchboardManager : MonoBehaviour {

	public static SwitchboardManager instance;
	public GameObject[] plugs;
	public GameObject[] customerLights;
	public GameObject[] recieverLights;
	public GameObject[] recievers;
	void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
