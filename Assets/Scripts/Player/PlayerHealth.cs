using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    public AudioClip firstLevel;
    public AudioClip secondLevel;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public Color deadColour = new Color(1f, 0f, 0f, 1f);
    public GameObject player;
    //public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    FirstPersonController fpc;

    //Animator anim;
    AudioSource playerAudio;
    AudioListener audioListener;
    //PlayerMovement playerMovement;
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
    bool colorDead;
    public AudioSource levelMusic;
    public GameObject levelMusicObj;
    public GameObject deathScreen;
    public GameObject winScreen;

    void Awake ()
    {
        fpc = GameObject.FindObjectOfType<FirstPersonController>();   
        //anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        audioListener = GetComponent<AudioListener>();
        //playerMovement = GetComponent <PlayerMovement> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        levelMusicObj = GameObject.Find("Level Music");
        levelMusic = levelMusicObj.GetComponent<AudioSource>();
        deathScreen.SetActive(false);
        winScreen.SetActive(false);
    }


    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
            }
        }
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        if(isDead)
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.red, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        //playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Debug.Log("Death");
            Death ();
            isDead = true;
        }
    }


    void Death ()
    {
        isDead = true;

        
        levelMusic.Stop();
        levelMusic.clip = deathClip;
        levelMusic.Play();
        playerAudio.clip = deathClip;

        fpc.m_MouseLook.lockCursor = false;
        //fpc.m_WalkSpeed = 0;
        //fpc.m_RunSpeed = 0;
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
