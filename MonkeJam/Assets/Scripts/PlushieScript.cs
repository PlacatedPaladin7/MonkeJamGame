
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlushieScript:MonoBehaviour
{


	public void PlushieUsed ()
	{
	
		gameObject.GetComponent<Collider> ().enabled = false;
		gameObject.GetComponent<Renderer> ().enabled = false;
		StartCoroutine(PlushieRecharge());

	}

	IEnumerator PlushieRecharge ()
	{
		yield return new WaitForSeconds (20);

		gameObject.GetComponent<Collider> ().enabled = true;
		gameObject.GetComponent<Renderer> ().enabled = true;

	}

	
	


}
