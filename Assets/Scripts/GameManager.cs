using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject lifePanel;
    private int lives = 3;
    private int Score = 0;
    public AudioSource Audio { get; set; }
    public bool GameOver { get; set; }



    private void Awake()
    {
        instance = this;
        Audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Scene1");

        }
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

    }
    public void ScoreText()
    {

        if (!GameOver)
        {
            Score++;
            scoreText.text = Score.ToString();
        }

    }
    public IEnumerator LoadThisScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Scene1");

    }


}


