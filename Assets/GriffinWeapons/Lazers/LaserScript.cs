using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserScript : MonoBehaviour {

    float recoilSpeed = 0.01f;
    LineRenderer line;
    Light light1;
    ParticleSystem muzzleFlash;
    public int damagePerShot = 10;
    public int damagePerCannon = 100;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    int shootableMask;
    public AudioClip laserBeam;
    AudioSource laserAudio;
    CharacterController charCtrl;
    Material originalLineRendererMat;
    Material defaultMaterial;
    public Slider chargeSlider;
    
    

    private void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        laserAudio = GetComponent<AudioSource>();
    }

    void Start () {
        
        charCtrl = gameObject.GetComponent<CharacterController>();

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;

        light1 = gameObject.GetComponent<Light>();
        light1.enabled = false;

        muzzleFlash = gameObject.GetComponentInChildren<ParticleSystem>();
        originalLineRendererMat = line.material;
        
	}
/*
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireLaser();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopLaser();
        }
    }
    */
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            muzzleFlash.Play();
            StopCoroutine("FireLaser");
            StartCoroutine("FireLaser");
            laserAudio.Play();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            muzzleFlash.Stop();
            laserAudio.Pause();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            StopCoroutine("FireCannon");
            StartCoroutine("FireCannon");
        }
        if (Input.GetButtonUp("Fire2"))
        {

        }
	}

    // Move current weapon to zoomed in position smoothly over time
    IEnumerator MoveToPosition(Vector3 newPosition, float time)
    {
        float elapsedTime = 0;
        var startingPos = transform.position;

        while (elapsedTime < time)
        {
            transform.position = Vector3.Lerp(startingPos, newPosition, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
        }
        yield return null;
    }

    IEnumerator FireCannon()
    {
        
        line.startWidth = 0.15f;
    
        line.endWidth = 10f;

        line.material = defaultMaterial;
        line.material.color = Color.red;

        while (Input.GetButton("Fire2") && KillCountCharger.charge > 0)
        {   
            line.enabled = true;
            KillCountCharger.charge -= 20;
            chargeSlider.value = KillCountCharger.charge;
            RaycastHit hit2;
            Vector3 p1 = transform.position;
            Ray ray = new Ray(transform.position, transform.forward);
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);

            line.SetPosition(0, ray.origin);

            RaycastHit[] rayHitArray = Physics.SphereCastAll(p1, 1f, transform.forward);
            Physics.Raycast(ray, out hit2, 100);
            line.SetPosition(1, ray.GetPoint(100));

            foreach (RaycastHit i in rayHitArray)
            {
                if (i.rigidbody)
                {
                    i.rigidbody.AddForceAtPosition(transform.forward * 1000, i.point);
                    Health enemyHealth = i.collider.GetComponent<Health>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damagePerCannon);
                        
                    }
                }
            }

            yield return null;
        }
        line.enabled = false;
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;
        line.startWidth = 0.15f;
        line.endWidth = 0.15f;
        line.material = originalLineRendererMat;
        
        while (Input.GetButton("Fire1"))
        {
            
            line.GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, Time.time);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * 300, hit.point);
                    //Debug.Log(hit.collider);
               
                    Health enemyHealth = hit.collider.GetComponent<Health>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damagePerShot);
                    }
                }
            }
            else
                line.SetPosition(1, ray.GetPoint(100));
            
            yield return null;
        }
        

        line.enabled = false;
    }
    
}