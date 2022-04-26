using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    public GameObject pauseMenu;
    public CharacterController charController;
    public GameObject Player;


    public Vector3 currentPosition;
    //public float yAxisRotation; //save this

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
        TimeTickSystem.OnTick += TimeTickSystem_OnTick;
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            LoadPlayer();
        }
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.locked;
        //SaveData.current.Add(position);
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
        if (Input.GetKeyDown("escape"))
        {
            TakeDamage(8);
            if (!pauseMenu.activeSelf) {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            } else {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
        //position = transform.position;
    }

    void TakeDamage(int damage) {
        if (currentHealth > 0) {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        if (damage > 0) {
            ticksSinceDamage = 0;
        }
    }

    void TakeHunger(int hunger) {
        currentHunger -= hunger;
        hungerBar.SetHunger(currentHunger);
    }

    public void SavePlayer() {
        SerializationManager.Save(this);
    }

    public void LoadPlayer() {
        PlayerData data = SerializationManager.Load();

        currentHunger = data.hunger;
        hungerBar.SetHunger(currentHunger);
        currentHealth = data.health;
        healthBar.SetHealth(currentHealth);

        currentPosition.x = data.playerPosition[0];
        currentPosition.y = data.playerPosition[1];
        currentPosition.z = data.playerPosition[2];

        //currentRotation.x = data.playerAngle[0];
        //currentRotation.y = data.playerAngle[1];
        //transform.rotation = currentRotation;

        //currentRotation.Set(data.playerAngle[0], data.playerAngle[1], data.playerAngle[2], 1);
        //transform.rotation.y = data.playerAngle;
        charController.enabled = false;
        charController.transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        charController.enabled = true;
        //transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        transform.rotation = Quaternion.Euler(0f, data.playerAngle, 0f);
        //transform.TransformPoint(new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]));


        //transform.rotation = Quaternion.Euler(0.0f, data.playerAngle, 0.0f);
    }

    void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.name == "River")
        {
            Vector3 teleport = new Vector3(484f, 54f, 607f);
            Player.transform.position = teleport;
            teleport = Vector3.zero;
        }
    }

}
