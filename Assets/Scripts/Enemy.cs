using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    static public Enemy instance;
    [SerializeField] int enemyMove;
    private Rigidbody2D rigidBody;
    [SerializeField] AudioSource audioSource;
    public bool GameOver { get; set; }
    private void Awake()
    {
        instance = this;
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector3.left * enemyMove;
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Edge"))
        {

            transform.localScale = new Vector3(-1, 1, 1);
            rigidBody.velocity = Vector3.left * enemyMove;

        }


        if (collision.gameObject.CompareTag("SecondEdge"))
        {

            transform.localScale = new Vector3(1, 1, 1);
            rigidBody.velocity = Vector3.right * enemyMove;

        }


        if (collision.gameObject.CompareTag("Player"))
        {

            //Player.instance.animator.SetBool("Death", true);
            //StartCoroutine(GameManager.instance.LoadThisScene());
            SaveLife.instance.Life();
            audioSource.Play();
            print("Dead by Ghost");
        }

    }

}
