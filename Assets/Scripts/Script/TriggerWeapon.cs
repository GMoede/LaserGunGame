using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWeapon : MonoBehaviour {
    public GameObject weapon;
    
    private void OnTriggerEnter(Collider other)
    {
        
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerWeaponsController>().EquipWeapon();
        Destroy(weapon);
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
