using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isMoving = true;
    [SerializeField] int enemyMove;
    Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(enemyMove * Time.deltaTime, 0, 0);
        }
    }


        private void OnTriggerEnter2D(Collider2D collision)
        {   

        if (collision.gameObject.CompareTag("Edge"))
        {
            isMoving = false;
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = Vector3.left * enemyMove; 
        }
         if (collision.gameObject.CompareTag("SecondEdge"))
        {
            
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = Vector3.right * enemyMove;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
        }
    }
    
}
