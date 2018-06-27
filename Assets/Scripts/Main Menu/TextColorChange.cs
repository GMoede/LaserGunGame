using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextColorChange : MonoBehaviour {

public TextMesh theText;

 		void OnMouseOver()
	 {
       theText = GetComponent<TextMesh>();
       theText.color = Color.red; //Or however you do your color
	 }

	 void OnMouseExit()
	 {
			 theText.color = Color.black; //Or however you do your color
	 }
}
