using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour {
	public void PlayGamez()
	{
			SceneManager.LoadScene(1);
	}
	public void QuitGamez()
	{
			SceneManager.LoadScene(0);
	}
}
