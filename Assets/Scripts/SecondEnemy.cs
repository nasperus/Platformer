using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float enemyMovement;
    private new AudioSource audio;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * enemyMovement;
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            rb.velocity = Vector2.down * enemyMovement;
            transform.localScale = new Vector2(1, 1);
        }

        if (collision.gameObject.CompareTag("SecondBorder"))
        {
            rb.velocity = Vector2.up * enemyMovement;
            transform.localScale = new Vector2(-1, 1);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.LivePanel();
            audio.Play();
        }

    }
}
