using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    public int score = 1;
    static public GameManager instance;

    private void Awake()
    {
        instance = this;
    }
  


    public void ScoreText()
    {
        text.text = score.ToString();
        score++;
    }
}


