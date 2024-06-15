using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPointScript : MonoBehaviour
{
	public bool isTaken;
	
	void Update ()
	{
		switch(isTaken)
		{
			case false:
			gameObject.GetComponent<Collider>().enabled = false;
			gameObject.GetComponent<Renderer> ().enabled = false;
			break;

			case true:
			gameObject.GetComponent<Collider> ().enabled = true;
			gameObject.GetComponent<Renderer> ().enabled = true;
			break;
		}
	}
}
