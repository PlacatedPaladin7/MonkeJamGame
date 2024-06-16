using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGrabber : MonoBehaviour
{

	public TextMeshProUGUI FinalScore;
	float score;

	void Awake ()
  	{
	 
		score = GameObject.FindGameObjectWithTag("MenuMaster").GetComponent<ScoreSaverScript>().finalScore;
		FinalScore.text = score.ToString("F0");
		 
	}
}
