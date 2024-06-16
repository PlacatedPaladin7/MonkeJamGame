using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSaverScript:MonoBehaviour
{
	public float finalScore;

	void Awake ()
	{
		DontDestroyOnLoad (this.gameObject);
		SceneManager.LoadScene ("MainMenu");
	}


}
