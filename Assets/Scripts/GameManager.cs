using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    private int Score { get; set; }
    static public GameManager instance;

    private void Awake()
    {
        instance = this;
    }
  


    public void ScoreText()
    {
        Score++;
        text.text = Score.ToString();
        
    }
}


