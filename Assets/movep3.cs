using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class movep3 : MonoBehaviour
{

    public float Move_speed = 10f;
    public float Move_dis = 50f;
    private float Distance = 1f;
    bool flag = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Distance < Move_dis && flag == false)
        {
            transform.Translate(Vector3.back * Move_speed * Time.deltaTime);
            Distance = Distance + Move_speed * Time.deltaTime;
        }

        if (Distance >= Move_dis && flag == false)
        {
            flag = true;
            Distance = 0f;
        }

        if (Distance >= Move_dis && flag == true)
        {
            flag = false;
            Distance = 0f;
        }

        if (flag == true)
        {
            transform.Translate(Vector3.forward * Move_speed * Time.deltaTime);
            Distance = Distance + Move_speed * Time.deltaTime;
        }




    }
}

