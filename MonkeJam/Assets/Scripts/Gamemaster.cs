using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gamemaster : MonoBehaviour
{
	PlayerController controller;
    public float timeLimit = 500;
    public float playerScore = 0;
	int chosenpoint;
	public float numberOfPoints;
	public float finishedPoints = 0;
	bool readyForPoints;
	public int maxPoints = 4;
	public float mouseMeter;
	public bool mouseRaids;
	public float raidCoutdown = 7;

	[SerializeField] public GameObject[] dropPoints;
	void Awake ()
	{

		controller = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
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

		mouseMeter += (2 * (Time.deltaTime / controller.speed));
	
		if(mouseMeter >= 60)
		{
			timeLimit -= Time.deltaTime * 2;
		}

		if(mouseRaids)
		{
			raidCoutdown -= Time.deltaTime;
		}

		if(raidCoutdown <= 0)
		{
          mouseRaids = false;
			raidCoutdown = 7;
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


	public void MouseGetsPlushie ()
	{
	 mouseRaids = true;
	}
}
