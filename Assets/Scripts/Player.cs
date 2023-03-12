using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] int jumpForce;
    [SerializeField] float speed;
    AudioSource audio;
    private bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
      
    }

    
    void Update()
    {

        PlayerMovement();
        
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += horizontal * speed * Time.deltaTime * Vector3.right;

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector2.up * jumpForce;
            audio.Play();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {

            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isJumping = true;
        }
    }


}
