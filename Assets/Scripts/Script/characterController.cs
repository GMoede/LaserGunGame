using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
    //public float speed = 10.0F;
    public float walkSpeed = 10.0F;
    public float runSpeed = 20.0F;
    public float speed = 10.0F;
    public Rigidbody rb;
    bool isgrounded = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;	
	}
	
	// Update is called once per frame
	void Update () {
        float translation;
        float straffe;
        if(Input.GetKeyDown("left shift"))
        {
            speed = runSpeed;
        }
        if(Input.GetKeyUp("left shift"))
        {
            speed = walkSpeed;
        }
        if (Input.GetKeyDown("space") && isgrounded)
        {
            rb.velocity = new Vector3(0, 6, 0);
        }
        
        translation = Input.GetAxis("Vertical") * speed;
        straffe = Input.GetAxis("Horizontal") * speed;
        /*if (Input.GetKeyDown("Positive Button")) {
            translation *= 2.0F;
            straffe *= 2.0F;
        }*/
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
	}
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "floor")
        {
            isgrounded = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "floor")
        {
            isgrounded = false;
        }
    }
}
