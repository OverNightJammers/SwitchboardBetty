using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour 
{
	public static GM instance;

	public GameObject startPanel;
	public GameObject gameOverPanel;

	public GameObject healthBarPivot;

	public Text countdownText;

	public bool gameStarted = false;



	private float health = 100;
	// Use this for initialization
	void Start () {
		instance = this;
		StartCoroutine (WaitForStart ());
	}
	
	// Update is called once per frame
	void Update () {

		if (!gameStarted && gameOverPanel.activeInHierarchy) {
			if (Input.GetMouseButtonDown (0))
				SceneManager.LoadScene (0);
		}
		
	}


	public void TakeHit(float value){
		health -= value;

		if (health < 0) {
			health = 0; 
			gameStarted = false;
			gameOverPanel.SetActive (true);
		}

		healthBarPivot.transform.localScale = new Vector3 (health / 100, healthBarPivot.transform.localScale.y, healthBarPivot.transform.localScale.z);
	}

	public void AddHealth(float value){
		health += value;

		if (health > 100)
			health = 100;

		healthBarPivot.transform.localScale = new Vector3 (health / 100, healthBarPivot.transform.localScale.y, healthBarPivot.transform.localScale.z);
	}


	IEnumerator WaitForStart(){
		yield return new WaitForSeconds (2);
		startPanel.SetActive (true);
		yield return new WaitForSeconds (1);
		countdownText.text = "2";
		yield return new WaitForSeconds (1);
		countdownText.text = "1";
		yield return new WaitForSeconds (1);
		countdownText.text = "Begin";
		gameStarted = true;
		yield return new WaitForSeconds (1);
		startPanel.SetActive (false);
		countdownText.text = "3";
	}
}
