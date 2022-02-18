using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpThrust;
    public float forward;
    public float sideways;
    private bool isGrounded;
    private bool jumpQueue;
    private Vector3 playerVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    public float horizontalSpeed = 2.5f;
    public float verticalSpeed = 2.5f;
    public float yaw = 2f;
    public float pitch = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalSpeed * Input.GetAxis("Mouse Y");
    }

    // Update is called once per frame
    void Update() 
    {
        if (Input.GetKeyDown("space"))//check to see if on ground
        {
            if (isGrounded) {
                jumpQueue = true;
            }
        }
        yaw += horizontalSpeed * Input.GetAxis("Mouse X");
        pitch -= verticalSpeed * Input.GetAxis("Mouse Y");
        rb.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);  
    }

    void FixedUpdate() {

        if (jumpQueue) {
            rb.AddForce(transform.up * jumpThrust);
            jumpQueue = false;
        }
        
        if (Input.GetKey(KeyCode.A)) { 
            playerVelocity.x = -sideways;
        } else if (Input.GetKey(KeyCode.D)) {
            playerVelocity.x = sideways;
        } else { 
            playerVelocity.x = 0; }

        if (Input.GetKey(KeyCode.W)) {
            playerVelocity.z = forward;

        } else if (Input.GetKey(KeyCode.S)) {
            playerVelocity.z = -forward;
        } else { 
            playerVelocity.z = 0; 
        }
        playerVelocity.y = rb.velocity.y;
        rb.velocity = playerVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == ("Ground"))
        {
            isGrounded = true;
        }
    }
    
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.name == ("Ground"))
        {
            isGrounded = false;
        }
    }

    
}
