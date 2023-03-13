using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool isMoving = true;
    [SerializeField] int enemyMove;
     Rigidbody2D rigidBody;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
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
            rigidBody.velocity = Vector3.left * enemyMove; 
        }

        else if (collision.gameObject.CompareTag("SecondEdge"))
        {
            
            transform.localScale = new Vector3(1, 1, 1);
            rigidBody.velocity = Vector3.right * enemyMove;
        }

       
    }
    
}
