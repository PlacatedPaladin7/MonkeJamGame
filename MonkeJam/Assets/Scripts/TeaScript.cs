using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaScript : MonoBehaviour
{
	Rigidbody rb;
	public Gamemaster gm;
  
	
	void Awake ()
	{

		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<Gamemaster>();
		rb = gameObject.GetComponent<Rigidbody> ();
		rb.AddForce (transform.forward * 1000);
		rb.AddForce (transform.up * 200);
	}

	void OnTriggerEnter (Collider other)
	{

		if(other.gameObject.tag == "teaDropOff")
		{
			gm.playerScore += 5 * (60 / gm.mouseMeter);
			if(gm.mouseRaids)
			{
				gm.playerScore += 3 * (60 / gm.mouseMeter);
			}
			other.gameObject.GetComponent<DropPointScript> ().isTaken = false;
			gm.finishedPoints++;
			gm.ProgressCheck ();
			Destroy (gameObject);
		}

	}

	void Update ()
	{
		transform.Rotate (0,40 * Time.deltaTime,0);
	}

}
