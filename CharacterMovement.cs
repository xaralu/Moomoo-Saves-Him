using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class CharacterMovement : MonoBehaviour
{
    //defining the variables that will hold each component of the movement - speed, jumping, x and z axis movement.
    public float speed;
    public float jumpForce;
    Rigidbody rb;
    public bool playerGrounded = true;
    private float horizontalInput;
    private float forwardInput;
    // private float upInput;
   
    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    void Update () {
        if (transform.position.y < -5f) {
            //SceneManager.LoadScene("Bootstrap");
        }

        if (Input.GetButtonDown("Jump") && playerGrounded){
            // rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            rb.AddForce((Vector3.up * jumpForce * Time.deltaTime), ForceMode.Impulse);
            // transform.position += Vector3.up * Time.deltaTime;
            //this also isnt working
            playerGrounded = false;
        }
    }
   
   //playergrounded isnt working???
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // transform.Translate(horizontalInput * speed, 0, forwardInput * speed);
        rb.AddForce(new Vector3(horizontalInput * speed, 0, forwardInput * speed), ForceMode.Impulse);

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Floor") {
            playerGrounded = true;
        }
    }
}
