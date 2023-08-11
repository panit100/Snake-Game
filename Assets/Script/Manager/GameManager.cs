using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public enum GameStage
{
    START,
    PLAYING,
    END,
}

public class GameManager : MonoBehaviour
{
    public const string HIGHSCORE = "HighScore";
    public static GameManager Instance {get; private set;}

    GameStage currentStage = GameStage.START;  

    [SerializeField] GameObject endGameUI;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text scoreText;

    void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        OnChangeStage(GameStage.START); 
    }

    public void OnChangeStage(GameStage gameStage)
    {
        currentStage = gameStage;

        switch(currentStage)
        {
            case GameStage.START:
                ToggleEndGameUI(false);
                break;
            case GameStage.PLAYING:
                break;
            case GameStage.END:
                SaveHighScore();
                SetScoreText();
                ToggleEndGameUI(true);
                break;
        }
    }    

    void ToggleEndGameUI(bool toggle)
    {
        endGameUI.SetActive(toggle);
    }

    public void Restart()
    {
        if(currentStage == GameStage.END)
            SceneManager.LoadScene(0);
    }

    void SaveHighScore()
    {
        var tempHighScore = PlayerPrefs.GetInt(HIGHSCORE,0);

        if(ScoreManager.Instance.GetScore() > tempHighScore)
            tempHighScore = ScoreManager.Instance.GetScore();

        PlayerPrefs.SetInt(HIGHSCORE,tempHighScore);
        PlayerPrefs.Save();

        highScoreText.text = $"{tempHighScore}"; 
    }

    void SetScoreText()
    {
        scoreText.text = $"{ScoreManager.Instance.GetScore()}"; 
    }

    public GameStage GetCurrentStage()
    {
        return currentStage;
    }
}
