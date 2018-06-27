using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {
   
    
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "Cube(10)")
            {
                Destroy(col.gameObject);
            }
        }
    
}
