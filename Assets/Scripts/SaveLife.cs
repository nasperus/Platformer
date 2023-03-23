using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLife : MonoBehaviour
{
    public static SaveLife instance;

    [SerializeField] GameObject[] obj;
    public static int score = 0;
    public static bool check = true;

    private void Awake()
    {
        instance = this;
    }

    public void Life()
    {

        while (score < obj.Length)
        {



        }
    }
}
