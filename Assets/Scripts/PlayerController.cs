﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10.0f;
    float jumpSpeed = 25.0f;
    Animator animController;
    Rigidbody2D rb;
    Collider2D collider2D;
    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update(){
        Run();
        Jump();
    }

    private void Run(){
        float horizontalMove = Input.GetAxis("Horizontal") * speed * Time.deltaTime;   
        // float verticalMove = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        FlipCharacter(horizontalMove);
        bool isMoving = Mathf.Abs(horizontalMove) > 0;
        animController.SetBool("isRunning", isMoving);

        this.transform.Translate(horizontalMove, 0, 0);
    }

    private void Jump(){
        if(!collider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            animController.SetBool("isJumping", true);
            return;
        }
        
        animController.SetBool("isJumping", false);
        if(Input.GetButtonDown("Jump"))
                rb.velocity = new Vector2(0.0f, jumpSpeed);
        }

    private void FlipCharacter(float facingSpeed){
        if(Mathf.Abs(facingSpeed) > 0)
            this.transform.localScale = new Vector2(Mathf.Sign(facingSpeed), 1.0f);
    }
}
