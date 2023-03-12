using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;
    Rigidbody2D rigidBody;
    [SerializeField] float jumpForce;
    [SerializeField] float speed;
    [SerializeField] Animator animator;
    public GameObject child;
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
            animator.SetInteger("Run", -1);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            print("Dead by Spike");
            child.transform.GetChild(0).gameObject.SetActive(true);
            
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
