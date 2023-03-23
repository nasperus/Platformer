using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLife : MonoBehaviour
{
    public static SaveLife instance;

    [SerializeField] GameObject[] obj;
    public static int score = 3;
    public static bool check = true;

    private void Awake()
    {
        instance = this;
    }

    public void Life()
    {

        if (score <= obj.Length && score != 0)
        {
            score--;
            obj[score].SetActive(false);
        }

        if (score == 0)
        {
            GameManager.instance.GameOver = true;
        }
    }
}
