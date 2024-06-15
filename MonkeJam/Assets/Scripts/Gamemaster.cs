using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamemaster : MonoBehaviour
{
    public float timeLimit = 500;
    public float playerScore = 0;
	int chosenpoint;
	public float numberOfPoints;
	public float finishedPoints = 0;

	

	[SerializeField] public GameObject[] dropPoints;

	void Update ()
    {
        timeLimit -= Time.deltaTime;

		if(Input.GetKeyDown (KeyCode.L))
		{
		 NextDelivery();
		}
		
	
		
	}


    public void NextDelivery ()
    {
		DropPointScript dropScript;

	  chosenpoint = (UnityEngine.Random.Range (0,3));

		dropScript = dropPoints[chosenpoint].gameObject.GetComponent<DropPointScript>();

		if(numberOfPoints < 2)
		{

			switch(dropScript.isTaken)
			{

				case false:
				dropScript.isTaken = true;
				numberOfPoints++;
				break;

				case true:
				NextDelivery ();
				break;
			}

		}
    }

	public void ProgressCheck ()
	{
		if(finishedPoints >= numberOfPoints )
		{
			numberOfPoints = 0; finishedPoints = 0;	
			
		}
	}
}
