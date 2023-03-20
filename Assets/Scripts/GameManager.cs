using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject lifePanel;
    private int lives = 3;
    private int Score = 0;
    static public GameManager instance;
    public AudioSource Audio { get; set; }
    public bool GameOver { get; set; }
    private void Awake()
    {
        instance = this;


    }

    private void Start()
    {
        Audio = GetComponent<AudioSource>();
    }

    public void LivePanel()
    {
        if (lives > 0)
        {
            lives--;
            lifePanel.transform.GetChild(lives).gameObject.SetActive(false);

        }

        if (lives == 0)
        {
            GameOver = true;

        }

        //StartCoroutine(LoadThisScene());

    }
    public void ScoreText()
    {

        if (!GameOver)
        {
            Score++;
            text.text = Score.ToString();
        }

    }
    IEnumerator LoadThisScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Scene1");

    }


}


