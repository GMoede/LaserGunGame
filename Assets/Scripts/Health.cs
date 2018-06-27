using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Networking;
using System.Collections;

public class Health : MonoBehaviour
{

    public const int maxHealth = 100;
    public bool destroyOnDeath;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
    Animator anim;
    public Slider chargeSlider;
    public Text killCount;
    public bool isDead = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        //if (!isServer)
        //  return;
        //Debug.Log("takeDamage");
        if (currentHealth > 0)
        {
            currentHealth -= amount;
        }
        if (currentHealth <= 0)
        {
            
            if (destroyOnDeath)
            {
                ParticleSystem deathP = gameObject.GetComponent<ParticleSystem>();
                anim.SetTrigger("Dead");
                deathP.Play();
                Destroy(gameObject, 1.5f);
                if (isDead == false)
                {
                    KillCountCharger.killCount += 1;
                    killCount.text = KillCountCharger.killCount.ToString();
                }
                isDead = true;
                
                if(KillCountCharger.charge < 200)
                {
                    KillCountCharger.charge += 1;
                    chargeSlider.value = KillCountCharger.charge;
                }
                
            
            }
            
        }
    }

    void OnChangeHealth(int currentHealth)
    {
        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }
}