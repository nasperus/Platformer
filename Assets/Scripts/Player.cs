using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    static public Player instance;
    Rigidbody2D rigidBody;
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    private AudioSource play;
    private bool isJumping, jumping;
    [SerializeField] float jumpTime;
    private float jumpTimeCounter;


    private void Awake()
    {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        play = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!GameManager.instance.GameOver)
        {
            PlayerMovement();

        }
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += horizontal * speed * Time.deltaTime * Vector3.right;

        if (Input.GetButtonDown(("Jump")) && !isJumping)
        {
            jumpTimeCounter = jumpTime;
            jumping = true;
            rigidBody.velocity = Vector2.up * jumpForce;
            play.Play();
            animator.SetInteger("Run", 1);

        }

        if (Input.GetButton("Jump") && jumping == true && jumpTimeCounter >= 0)
        {

            rigidBody.velocity = Vector2.up * jumpForce;
            jumpTimeCounter -= Time.deltaTime;


        }

        if (Input.GetButtonUp("Jump"))
        {
            jumping = false;
        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.localScale = new Vector3(-1, 1, 1);

        }

        if (Input.GetKey(KeyCode.A))
        {

            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isJumping = false;
            animator.SetInteger("Run", -1);
        }


        if (collision.gameObject.CompareTag("Spike"))
        {
            //animator.SetBool("Death", true);
            GameManager.instance.LivePanel();
            StartCoroutine(GameManager.instance.LoadThisScene());
            Enemy.instance.GameOver = true;
            print("Dead by Spike");

        }

        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            Destroy(gameObject);
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
