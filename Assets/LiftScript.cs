using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiftScript : MonoBehaviour {

    public GameObject gameObject;
    public bool flag = false;

    // Update is called once per frame
    private void Start()
    {
        flag = false;
    }
    void Update () {
        if (flag == true)
        {
            gameObject.transform.Translate(0, 1, 0);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.transform.parent.name);
        flag = true;
        
    }
}
