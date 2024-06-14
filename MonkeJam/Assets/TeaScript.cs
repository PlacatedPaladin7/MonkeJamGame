using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaScript : MonoBehaviour
{
	Rigidbody rb;

	void Awake ()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * 700);
		rb.AddForce (transform.up * 200);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "teaDropOff")
		{
			//Add destroy and add to player score + next delivery
			Destroy (gameObject);
		}

	

		
	}

	void Update ()
	{
		transform.Rotate (0,40 * Time.deltaTime,0);
	}

}
