using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
	public Slider mouseSlider;

	public Sprite[] mouseMoods;
	public Image mouseSprite;


	public TextMeshProUGUI timerText;
	public TextMeshProUGUI monkeBucksText;
	public TextMeshProUGUI teaText;
	public TextMeshProUGUI speedText;

	[SerializeField] public GameObject[] dropPoints;
	void Awake ()
	{

		controller = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		readyForPoints = true;
		GameObject.FindGameObjectWithTag ("MenuMaster").GetComponent<ScoreSaverScript> ().finalScore = playerScore;
	}
	
	void Update ()
    {
	
		timerText.text = timeLimit.ToString ("F0");
		monkeBucksText.text = playerScore.ToString ("F0");
		teaText.text = "Tea Boxes Left:" + controller.numberOfTea.ToString ("F0");
		speedText.text =  controller.speed.ToString ("F0");
		mouseSlider.value = mouseMeter;	

		timeLimit -= Time.deltaTime;

		if(readyForPoints && numberOfPoints < maxPoints)
		{
			NextDelivery ();
		}
		else if(numberOfPoints >= maxPoints)
		{
			readyForPoints = false;
		}

		mouseMeter += (3 * ((Time.deltaTime / controller.speed)/ 100));
	
		if(mouseMeter >= 1)
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


		

		if(Mathf.Clamp (mouseMeter,0.8f,0.19f) == mouseMeter)
		{
			mouseSprite.sprite = mouseMoods[0];
		}

		if(Mathf.Clamp (mouseMeter,0.2f,0.39f) == mouseMeter)
		{
			mouseSprite.sprite = mouseMoods[1];
		}

		if(Mathf.Clamp (mouseMeter,0.4f,0.59f) == mouseMeter)
		{
			mouseSprite.sprite = mouseMoods[2];
		}

		if(Mathf.Clamp (mouseMeter,0.6f,0.79f) ==mouseMeter)
		{
			mouseSprite.sprite = mouseMoods[3];
		}

		if(mouseMeter > 0.8f)
		{
			mouseSprite.sprite = mouseMoods[4];
		}


		if(timeLimit <= 0 && playerScore >= 50000)
		{
			
		 	GameObject.FindGameObjectWithTag ("MenuMaster").GetComponent<ScoreSaverScript> ().finalScore = playerScore;
		    SceneManager.LoadScene ("VictoryScreen");
		}
		else if(timeLimit <= 0 && playerScore < 50000)
		{
			
			GameObject.FindGameObjectWithTag ("MenuMaster").GetComponent<ScoreSaverScript> ().finalScore = playerScore;
			SceneManager.LoadScene ("LoseScreen");
		}

		if(Input.GetKeyDown (KeyCode.Escape))
		{
			SceneManager.LoadScene ("MainMenu");
			
		}
	}


    public void NextDelivery ()
    {
		DropPointScript dropScript;

	  chosenpoint = (UnityEngine.Random.Range (0,maxPoints));

		dropScript = dropPoints[chosenpoint].gameObject.GetComponent<DropPointScript>();

		if(numberOfPoints < 6)
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
		mouseMeter = 0;
	mouseSprite.sprite = mouseMoods[5];
		
	}
}
