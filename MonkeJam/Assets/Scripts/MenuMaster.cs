using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMaster : MonoBehaviour
{
    public GameObject controls;

    public void StartGame ()
    {
        SceneManager.LoadScene ("MainLevel");
    }
    public void MainMenu ()
    {
        SceneManager.LoadScene ("MainMenu");
    }

    public void Options ()
    {
      controls.SetActive (true);   
    }

    public void CloseOptions ()
    {
		controls.SetActive (false);
	}
 
   
}
