using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkeyWander : MonoBehaviour {

    public float moveSpeed = 3f;
    public float rotSpeed = 100f;
    public GameObject drumstick;


    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private bool isDead = false;
    private bool danger = false;
    private IEnumerator wandering;

    public Animator anim;

    void Start() {
        wandering = Wander();
        anim = GetComponent<Animator>();
        anim.SetInteger("Moving", 0);
        anim.SetBool("IsDead", false);
    }

    //anim works by changing the animation state of the obj which is defined by integers 0-2 to either idel, run, walk or bool die
    void Update() {
      if(!isDead)
      {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            anim.SetInteger("Moving", 1);
            transform.position += -(transform.right) * moveSpeed * Time.deltaTime;
        }
        //runs if player nearby
        if (danger == true)
        {
          anim.SetInteger("Moving", 2);
          transform.position += -(transform.right) * (moveSpeed*4) * Time.deltaTime;
          danger = false;
        }
      }
    }

    IEnumerator Wander()
    {
      int rotTime = Random.Range(1, 3);
      int rotateWait = Random.Range(1, 4);
      int rotateLorR = Random.Range(1, 2);
      int walkWait = Random.Range(1, 4);
      int walkTime = Random.Range(1, 5);

      isWandering = true;
      anim.SetInteger("Moving", 0);
      yield return new WaitForSeconds(walkWait);
      isWalking = true;
      yield return new WaitForSeconds(walkTime);
      anim.SetInteger("Moving", 0);
      isWalking = false;
      yield return new WaitForSeconds(rotateWait);
      anim.SetInteger("Moving", 0);
      if (rotateLorR == 1)
      {
          isRotatingRight = true;
          yield return new WaitForSeconds(rotTime);
          anim.SetInteger("Moving", 0);
          isRotatingRight = false;
      }
      if (rotateLorR == 2)
      {
          isRotatingLeft = true;
          yield return new WaitForSeconds(rotTime);
          anim.SetInteger("Moving", 0);
          isRotatingLeft = false;
      }
      isWandering = false;
    }

    IEnumerator Death()
    {
      anim.SetBool("IsDead", true);
      yield return new WaitForSeconds(2);
      Destroy(this.gameObject);
      //kills animal replaces with food
      Instantiate(drumstick, this.transform.position, this.transform.rotation);
    }

    void KillChicken()
    {
      Debug.Log("killed");
      StopCoroutine(Wander());
      isDead = true;
      anim.SetInteger("Moving", 0);
      StartCoroutine(Death());
    }

    void run()
    {
      danger = true;
    }

    void OnCollisionEnter(Collision other)
    {
      //makes it so if the animal runs onto water, it is thrown back a good 50 units to prevent it from falling through
      if(other.gameObject.name == "River")
      {
        Debug.Log("Swim");
        Vector3 teleport = this.transform.position;
        Debug.Log(teleport);
        if(teleport.x < -75f)
        {
          teleport.x += -50.0f;
        }
        else
        {
          teleport.x += 50.0f;
        }
        teleport.y += 15.0f;
        Debug.Log(teleport);
        this.transform.position = teleport;
        teleport = Vector3.zero;
      }
    }
}
