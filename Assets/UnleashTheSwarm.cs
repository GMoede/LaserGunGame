using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnleashTheSwarm : MonoBehaviour
{
	public GameObject wall;
	public Transform startpos;
	public Transform endpos;
	public float speed = 10f;


	void OnTriggerEnter(Collider other)
		{
							{
						Debug.Log("Object Entered Trigger");
						wall.transform.position = Vector3.Lerp(wall.transform.position,endpos.position,Time.deltaTime * speed);
						//Distance = Distance + speed * Time.deltaTime;
					    }
  	}
}
