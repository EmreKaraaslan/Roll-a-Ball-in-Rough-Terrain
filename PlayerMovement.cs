using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed=30f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField]  float jumpHeight;
    [SerializeField] float duration;

    Rigidbody rigidbody;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerJump();
    }

    

    void PlayerMove()
    {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            rigidbody.AddForce(30 * movement * playerSpeed * Time.deltaTime);
       
           
    }

    void PlayerJump()
    {
       // if (transform.position.y<jumpAllowanceHeight && Input.GetKeyDown(KeyCode.Space))
       if (Input.GetKeyDown(KeyCode.Space))
       {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
          
       }
    }

   


}
