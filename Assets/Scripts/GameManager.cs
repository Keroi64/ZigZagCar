using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameStarted;
    public GameObject platformSpawner;

    public GameObject nextLevelPanel;


    [Header("GameOver")]
    public GameObject gameOverPanel;
    public GameObject newHighScoreImage;
    public Text LastScoreText;

    [Header("Score")]
    public Text scoreText;
    public Text bestText;
    public Text diamondText;
    public Text startText;

    int score = 0;
    int bestScore, totalDiamond, totalStar;
    bool countScore;

    public Text levelOneText;
    public Text levelUpText;

  


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        
            
    }

    void Start()
    {
        totalDiamond = PlayerPrefs.GetInt("totalDiamond");
        diamondText.text = totalDiamond.ToString();

        totalStar = PlayerPrefs.GetInt("totalStar");
        startText.text = totalStar.ToString();
        
        bestScore = PlayerPrefs.GetInt("bestScore");
        bestText.text = bestScore.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
        
    }
    public void GameStart()
    {
        isGameStarted = true;
        countScore = true;
        StartCoroutine(UpdateScore());
        platformSpawner.SetActive(true);


       

    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        LastScoreText.text = score.ToString();
        countScore = false;
        platformSpawner.SetActive(false);
       
        
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore",score);
            newHighScoreImage.SetActive(true);

        }
        
    }

    public void ReplayGame()
    {
        PlayerPrefs.SetInt("totalStar", 0);
        PlayerPrefs.SetInt("totalDiamond", 0);

        startText.text = "0";
        diamondText.text = "0";

        totalStar = 0;
        totalDiamond = 0;

        SceneManager.LoadScene("Level1");
        

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("totalStar", 0);
        PlayerPrefs.SetInt("totalDiamond", 0);

        startText.text = "0";
        diamondText.text = "0";

        SceneManager.LoadScene(1);
        Time.timeScale = 1;

        totalStar = 0;
        totalDiamond = 0;
    }


    IEnumerator UpdateScore()
    {
        while(countScore)
        {
            yield return new WaitForSeconds(1f);
            score++;
            if (score>bestScore)
            {
                scoreText.text = score.ToString();
                bestText.text = bestScore.ToString();
            }
            else
            {
                scoreText.text = score.ToString();
            }
            


        }

        

    }

    public void GetStar()
    {
        totalStar++;
        PlayerPrefs.SetInt("totalStar", totalStar);
        startText.text = totalStar.ToString();

        if (totalStar > 24)
        {
            nextLevelPanel.gameObject.SetActive(true);
            countScore = false;
            platformSpawner.SetActive(false);
            Time.timeScale = 0;
            
        }

    }
    public void GetDiamond()
    {
        totalDiamond++;
        PlayerPrefs.SetInt("totalDiamond", totalDiamond);
        diamondText.text = totalDiamond.ToString();

        if (totalDiamond > 9)
        {
            nextLevelPanel.gameObject.SetActive(true);
            countScore = false;
            platformSpawner.SetActive(false);
            Time.timeScale = 0;
        }
        



    }

   
}
