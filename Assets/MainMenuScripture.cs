using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScripture : MonoBehaviour {
	public void PlayGame()
	{
			SceneManager.LoadScene(1);
	}
	public void QuitGame ()
	{
		Application.Quit();
		Debug.Log("The Game Has Quit");
	}
}
