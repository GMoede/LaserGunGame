using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour {
	public void PlayGames()
	{
			SceneManager.LoadScene(1);
	}
	public void QuitGames()
	{
			SceneManager.LoadScene(0);
	}
}
