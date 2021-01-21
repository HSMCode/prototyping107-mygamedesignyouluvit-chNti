using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float jumpHeight;
    public bool isJumping = false; 
    private Rigidbody _rigidBody;
    

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        InvokeRepeating("Jump", 0.7f, 1.2f);

    }


    void Jump()
    {
        if (!isJumping) 
        {
  
            _rigidBody.AddForce(Vector3.up * jumpHeight); 
            isJumping = true;
            
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "ground") 
        {
            isJumping = false;
        }
    }



}
