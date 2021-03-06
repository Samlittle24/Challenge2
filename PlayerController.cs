﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    
    public float speed;
    public float jumpForce;
    public Text countText;
    public Text winText;
    public Text lifeText;
    public GameObject Player;


    private Rigidbody2D rb2d;
    private int count;
    private int lives;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        lives = 3;
        SetAllText();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        UnityEngine.Vector2 movement = new UnityEngine.Vector2(moveHorizontal, 0);
        rb2d.AddForce(movement * speed);
    }
    void OnCollisionStay2D(Collision2D collision)
    {
       if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new UnityEngine.Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetAllText();

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetAllText();
        }
        if (count == 4)
        {
            transform.position = new UnityEngine.Vector2(25f,-2f);
        }
        
        
        
    }
    void SetAllText()
    {
        lifeText.text = "Lives: " + lives.ToString();
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You win!";
        }
        if(lives == 0)
        {
            winText.text = "You Lose!";
        }
    }
}
