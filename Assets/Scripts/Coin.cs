using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource coin;
   
    private void Start()
    {
        coin = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coin.Play();
            GameManager.instance.ScoreText();
            Destroy(gameObject);

        }
    }
    
}
