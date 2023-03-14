using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;
    Rigidbody2D rigidBody;
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    public Animator animator;
    AudioSource play;
    private bool isJumping;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        play = GetComponent<AudioSource>();

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
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            play.Play();
            animator.SetInteger("Run", 1);

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
            animator.SetBool("Death", true);
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
