using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Runtime.CompilerServices;

public class BallMovement : MonoBehaviour
{
    Rigidbody rb;
    bool rightKey,leftKey,jumpKey = false;
    public float leftForce = 1000;
    public float rightForce = 1000;
    public float jumpForce = 220;
    bool isJumpPressed = true;
    bool isDoubleJumpEnabled = false;
    public float doubleJumpTime = 0.3f;
    float timeDifference = 1f;
    float firstKeyPressTime;
    bool canJump = false;
    public int starsCollected = 0;

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Game has started");
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isJumpPressed)
            {
                firstKeyPressTime = Time.time;
                isJumpPressed = false;
            }
            else
            {
                timeDifference = Time.time-firstKeyPressTime;
                isJumpPressed= true;
            
            }
        }
        if(timeDifference<=doubleJumpTime)
        {
            Jump();
            timeDifference = doubleJumpTime+1f;
        }
        else
        {
            isDoubleJumpEnabled = false;
        }

        if(Input.GetKey(KeyCode.L))
        {
            rightKey = true;
        }
        if(Input.GetKey(KeyCode.J))
        {
            leftKey = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }

        if(transform.position.y <=-0.5f)
        {
            
            FindObjectOfType<GameManager>().EndGame();
        }
        
    }

    void FixedUpdate()
    {
        if(rb.velocity.x>=-5f)
        {
            if(leftKey)
            {
                rb.AddForce(-leftForce*Time.deltaTime,0,0,ForceMode.Force);
                leftKey = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(-5f,rb.velocity.y,0);
        }
        if(rb.velocity.x<=5f)
        {
            if(rightKey)
            {
                rb.AddForce(rightForce*Time.deltaTime,0,0,ForceMode.Force);
                rightKey = false;
            }
        }
        else
        {
            rb.velocity = new Vector3(5f,rb.velocity.y,0);
        }
        
        if(canJump&&jumpKey)
        {
            Jump();
        }
    
    }

    void Jump()
    {
        
            rb.AddForce(0,jumpForce*Time.deltaTime,0,ForceMode.VelocityChange);
            jumpKey = false;
            canJump = false;
            
        
    }

     void OnCollisionEnter(Collision other)
    {
        
        if(other.collider.tag == "Ground")
        {
            Debug.Log("Hit "+other.collider.tag);
            canJump = true;
        }
        else
        {
           if(timeDifference<=doubleJumpTime)
           {
            canJump = true;
            Jump();
           }
           else
           {
            canJump = false;
           }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Star")
        {
            Destroy(other.gameObject);
            starsCollected++;
        }
        if(other.gameObject.tag == "End")
        {
            Debug.Log("Hit end");
            
            FindObjectOfType<GameManager>().NewGame();  

            
        }
    }

    

}
