using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMe : MonoBehaviour 
{
	GameObject go = null;
	Plane objPlane;
	Vector3 m0;

	Ray GenerateMouseRay()
	{
		Vector3 mousePosFar = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
		Vector3 mousePosNear = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

		Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
		Vector3 mousePosN = Camera.main.ScreenToWorldPoint (mousePosNear);

		Ray mr = new Ray(mousePosN, mousePosF-mousePosN);
		return mr;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)  && !go) 
		{
			Ray mouseRay = GenerateMouseRay ();
			RaycastHit hit;

			if (Physics.Raycast (mouseRay.origin, mouseRay.direction, out hit)) {
				if (hit.transform.name.Contains("aPlug_")) {
					go = hit.transform.gameObject;
					objPlane = new Plane (Camera.main.transform.forward * -1, go.transform.position);

					Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
					float rayDist;
					objPlane.Raycast (mRay, out rayDist);
					m0 = go.transform.position - mRay.GetPoint(rayDist);

				}
			}
		}

		if (Input.GetMouseButton (0) && go) 
		{
			Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			float rayDistance;
			if (objPlane.Raycast (mRay, out rayDistance))
				go.transform.position = mRay.GetPoint (rayDistance) + m0;
		} 

		if (Input.GetMouseButtonUp (0) && go) 
		{
				go = null;
		}
	}	
}
