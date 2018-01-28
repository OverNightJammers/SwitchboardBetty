using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomePanel : MonoBehaviour 
{
	public void OnPlayTouched()
	{
		SceneManager.LoadScene (1);
	}

	public void OnHowToTouched()
	{
		SceneManager.LoadScene (2);
	}

	public void OnExitTouched(){
		Application.Quit ();
	}




}
