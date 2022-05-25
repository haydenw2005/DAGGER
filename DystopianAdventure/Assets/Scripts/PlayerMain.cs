using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Determines behavior for the main player and item interaction
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
    public GameObject player;
    public float radius;
    public InventorySystem inventory;
    public HoverCarControl hoverCar;
    public GameObject deathScreen;
    public GameObject aliveUI;
    public TeleportScript teleportPad;
    public Vector3 currentPosition;

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
        if(Input.anyKeyDown) {
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
            if (Input.GetKey(KeyCode.E) && inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot.Count >= 1) {
              inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot[0].TryGetComponent<ItemObject>(out ItemObject item);
              if (item.referenceItem.id == "InventoryItem_Pork" || item.referenceItem.id == "InventoryItem_Chicken" || item.referenceItem.id == "InventoryItem_Steak" || item.referenceItem.id == "InventoryItem_Lamb") {
                  TakeHunger(-10);
                  Destroy(inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot[0]);
                  InventorySystem.current.Remove();
              } else if (item.referenceItem.id == "InventoryItem_BikeCrystal") {
                  if (hoverCar.switchSeats() == true) {
                      Destroy(inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot[0]);
                      GameObject.Find("/Canvas/AliveUI/ImportantUI/MissionPrompt").SendMessage("MissionOne");
                      InventorySystem.current.Remove();
                  }
              } else if (item.referenceItem.id == "InventoryItem_TeleportCrystal") {
                  if (teleportPad.turnOnTP() == true) {
                      Destroy(inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot[0]);
                      InventorySystem.current.Remove();
                  }
              }
            }
        }
        if(this.transform.position.x < -101f && this.transform.position.x > -997f && this.transform.position.z < 1998f && this.transform.position.z > 998.7f)
        {
            RenderSettings.fog = true;
        }
        else
            {
                RenderSettings.fog = false;
            }

        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);
        foreach (var hitCollider in hitColliders)
        {
          hitCollider.SendMessage("run", SendMessageOptions.DontRequireReceiver);
        }
        if(inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot.Count > 0)
        {
          GameObject.Find("/Canvas/AliveUI/NotImportantUI/InteractText").SendMessage("currentHeld", inventory.slots[inventory.getCurrentSlot()-1].itemsInSlot[0]);
        }
    }

    public void TakeDamage(int damage) {
        if (currentHealth > 0) {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        if (damage > 0) {
            ticksSinceDamage = 0;
        }
        if(currentHealth <= 0) {
            playerDeath();
        }
    }

    public void TakeHunger(int hunger) {

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

        charController.enabled = false;
        charController.transform.position = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
        charController.enabled = true;
        transform.rotation = Quaternion.Euler(0f, data.playerAngle, 0f);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "River")
        {
            //Start the coroutine we define below named TimeCoroutine.
            StartCoroutine(DeathScreenCoroutine());
        }
    }

    IEnumerator DeathScreenCoroutine()
    {
        // turn off ui turn on death screen
        aliveUI.SetActive(false);
        deathScreen.SetActive(true);

        //turn off character movement
        charController.enabled = false;

        //yield on a new YieldInstruction that waits for 4 seconds.
        yield return new WaitForSeconds(4);
        // turn death screen off and turn on all things i turned off
        deathScreen.SetActive(false);
        aliveUI.SetActive(true);
        charController.enabled = true;
        playerDeath();
    }

    private void playerDeath() {
        //Death Animation
        Vector3 teleport = new Vector3(573, 55f, 601f);
        player.transform.position = teleport;
        teleport = Vector3.zero;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
    }

}
