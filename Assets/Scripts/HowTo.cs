using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowTo : MonoBehaviour {

	public void OnExitClicked(){
		SceneManager.LoadScene (0);
	}
}
