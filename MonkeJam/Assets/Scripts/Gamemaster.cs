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
	bool readyForPoints;
	public int maxPoints = 4;
	

	[SerializeField] public GameObject[] dropPoints;
	void Awake ()
	{
		readyForPoints = true;
	}

	void Update ()
    {
        timeLimit -= Time.deltaTime;

		if(readyForPoints && numberOfPoints < maxPoints)
		{
			NextDelivery ();
		}
		else if(numberOfPoints >= maxPoints)
		{
			readyForPoints = false;
		}
		
	
		
	}


    public void NextDelivery ()
    {
		DropPointScript dropScript;

	  chosenpoint = (UnityEngine.Random.Range (0,maxPoints));

		dropScript = dropPoints[chosenpoint].gameObject.GetComponent<DropPointScript>();

		if(numberOfPoints < 5)
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
		if(finishedPoints >= numberOfPoints)
		{
			numberOfPoints = 0;
			finishedPoints = 0;
			StartCoroutine (NewDropPoints ());
		}
	}

	IEnumerator NewDropPoints ()
	{
		yield return new WaitForSeconds (3);
		readyForPoints = true;
 	}
}
