using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugScript : MonoBehaviour 
{

	public GameObject light;

	public bool isGrabbed = false;

	bool beenGrabbed = false;
	public bool isBlinking = false;
	public bool onHold = false;
	public bool gameStarted = false;
	public float waitTimer = 10;
	public float currentTimer = 0;
	GM gameManagerInstance;
	// Use this for initialization
	void Start () {
	
		// get first waitTimer
		gameManagerInstance = GM.instance;
		StartCoroutine(WaitForStart());

	}
	
	// Update is called once per frame
	void Update () {


		gameStarted = GM.instance.gameStarted;

		if (waitTimer > 0  && gameStarted) 
		{
			if (currentTimer < waitTimer) 
			{
				currentTimer += Time.deltaTime;

				if(currentTimer > waitTimer)
				{
					if (!isBlinking) {
						isBlinking = true;
						StartCoroutine (BlinkLight ());
					}

					if (!isGrabbed) {
						StartCoroutine (Waiting2Banswered ());
					}
				}
			}
		}


		if (isGrabbed && !beenGrabbed) 
		{
			beenGrabbed = true;

		}
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.transform.name.Contains ("Reciever")) {

			this.transform.localEulerAngles = new Vector3 (252, transform.localEulerAngles.y, transform.localEulerAngles.z);


		} else if (coll.transform.name.Contains ("Hold") || coll.transform.name.Contains("Operator")) {
			this.transform.localEulerAngles = new Vector3 (72, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
	}

	void OnTriggerExit()
	{
		transform.localEulerAngles = new Vector3 (0, 180, 0);
	}

	float GetWaitTimer()
	{
		float wait = Random.Range (1, 10);
		currentTimer = 0;

		return wait;
	}

	IEnumerator Waiting2Banswered(){
		while (!isGrabbed) 
		{
			yield return new WaitForSeconds (Random.Range(3,6));
			GM.instance.TakeHit (.5f);
		}

	}



	IEnumerator OnHold(){
		while (onHold) 
		{
			yield return new WaitForSeconds (Random.Range(3,6));
			GM.instance.TakeHit (.5f);
		}

	}

	IEnumerator BlinkLight()
	{
		while (!beenGrabbed) 
		{
			light.GetComponent<MeshRenderer> ().material.EnableKeyword ("_EMISSION");
			yield return new WaitForSeconds(.5f);
			light.GetComponent<MeshRenderer> ().material.DisableKeyword ("_EMISSION");
			yield return new WaitForSeconds(.5f);
			yield return null;
		}

	}

	IEnumerator WaitForStart()
	{
		yield return new WaitForSeconds (1);
		if (!gameStarted)
			StartCoroutine (WaitForStart ());
		else
			waitTimer = GetWaitTimer ();
	}
}
