using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoControl : MonoBehaviour
{
    public TMP_Text forcePowerText;
    public TMP_Text healthText;
    public int health = 100;
    public int forcePower = 100;
    public int fPRegenRate = 1;
    private float timeSinceLastHeal;
    public float fPRegenCooldown = 1;

    void Start()
    {
        timeSinceLastHeal = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + health;
        forcePowerText.text = "Force Power: " + forcePower;
        if (forcePower < 100 && (Time.time - timeSinceLastHeal > fPRegenCooldown))
        {
            timeSinceLastHeal = Time.time;
            forcePower += fPRegenRate;
            if (forcePower > 100) forcePower = 100;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        bool done = false;
        foreach (ContactPoint contact in collision.contacts)
        {

            print(contact.otherCollider.name);
            if (contact.otherCollider.name.Contains("BlasterFire"))
            {
                playerHit(10);
            }
        }
    }

    void playerHit(int damage)
    {
        health = health - damage;
        if(health < 0) health = 0;
    }

    void healPlayer(int heal)
    {
        health += heal;
        if(health > 100) health = 100;
    }

    
}
