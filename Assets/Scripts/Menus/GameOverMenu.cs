using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverMenu : MonoBehaviour {
public Slider healthSlider;
	void Update(){

			if (healthSlider.value == 0)
			{
				gameObject.SetActive(true);
			}
		}
	}
