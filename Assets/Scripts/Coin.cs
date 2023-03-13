using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    AudioSource play;
   
    private void Start()
    {
        play = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            play.Play();
            print("text");
            GameManager.instance.ScoreText();
            Destroy(gameObject);

        }
    }
    
}
