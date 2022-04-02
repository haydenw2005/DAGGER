using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int maxHunger = 100;
    public int currentHunger;
    public HealthBar healthBar;
    public HungerBar hungerBar;
    public float hungerRate;
    private int ticksSinceDamage;
    public int regenWait;
    public int regenHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
    }
    private void TimeTickSystem_OnTick (object sender, TimeTickSystem.OnTickEventArgs e) {
        if (e.tick % hungerRate == 0 && currentHunger > 0){ 
            TakeHunger(1);
        }
        else if (currentHunger == 0) {
            TakeDamage(2);
        }
        if (ticksSinceDamage > regenWait && currentHealth < 100 + regenHealth && currentHunger > 60) {
            TakeDamage(regenHealth);
        }
        else if (ticksSinceDamage > regenWait && currentHunger > 60) {
            TakeDamage(-1*(100-currentHealth));
        }
        ticksSinceDamage++;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TakeDamage(8);
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (damage > 0) {
            ticksSinceDamage = 0;
        }
    }

    void TakeHunger(int hunger) {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }


    //public Transform Spawn;
    public GameObject Player;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("hit");

        if(other.gameObject.name == "RiverWater")
        {
            Vector3 teleport = new Vector3(147f, 57f, 776f);
            Player.transform.position = teleport;
            teleport = Vector3.zero;
        }
    }

}
