using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitWander : MonoBehaviour {
    
    public float moveSpeed = 3f;
    public float rotSpeed = 100f;

    public Rigidbody rb;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;

    float randomX;  //randomly go this X direction
    float randomZ;  //randomly go this Z direction

    public Animation anim;

    void Start() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        randomX =  Random.Range(-3,3);
        randomZ = Random.Range(-3,3);
    }

    void Update() {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            rb.transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
        }
        if (isRotatingLeft == true)
        {
            rb.transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
        }
        if (isWalking == true)
        {
            anim.Play("Run1");
            rb.AddForce(new Vector3(randomX,0,randomZ), ForceMode.Acceleration);
            rb.transform.Translate(new Vector3(randomX,0,randomZ) * Time.deltaTime);
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

        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }

        isWandering = false;
    }

    /*
    void OnAnimatorMove ()
    {
        Debug.Log("hi");

        if(animator)
        {
            animator.applyRootMotion = false;
            Vector3 newPosition = transform.position;
            newPosition.x += animator.GetFloat("moveSpeed") * Time.deltaTime;
            transform.position = newPosition;
        }
    }
    */







    /*
    public float duration;    //the max time of a walking session (set to ten)
    public Rigidbody rb;
    float elapsedTime   = 0f; //time since started walk
    float wait          = 0f; //wait this much time
    float waitTime      = 0f; //waited this much time

    float randomX;  //randomly go this X direction
    float randomZ;  //randomly go this Z direction

    bool move = true; //start moving

    public Animation anim;

    void Start(){
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animation>();
        randomX =  Random.Range(-3,3);
        randomZ = Random.Range(-3,3);
    }

    void Update ()
    {
        //Debug.Log (elapsedTime);

        if (elapsedTime < duration && move) {
            //if its moving and didn't move too much
            Vector3 movementDirection = new Vector3(randomX,0,randomZ);
            movementDirection.Normalize();
            anim.Play("Run1");
            rb.transform.Translate(movementDirection * Time.deltaTime);
            elapsedTime += Time.deltaTime;

        } else if(wait == 0f) {
            //do not move and start waiting for random time
            move        = false;
            wait        = Random.Range (3, 8);
            waitTime    = 0f;
        }

        if (waitTime < wait && !move) {
            Debug.Log(wait);
            //you are waiting
            waitTime += Time.deltaTime;

        } else if(!move) {
            //you're done waiting
            Debug.Log("bye");
            move = true;
            elapsedTime = 0f;
            wait = 0f;
            randomX = Random.Range(-3,3);
            randomZ = Random.Range(-3,3);
        }
    }
    */

}
