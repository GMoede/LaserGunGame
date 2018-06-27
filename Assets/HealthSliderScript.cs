using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthSliderScript : MonoBehaviour {
public Slider healthSlider;
	void Start(){
		healthSlider.value = 100;
	}

	void Update(){
			healthSlider.value -= 1;
			if (healthSlider.value == 0)
			{
				gameObject.SetActive(false);
			}
		}
	}
