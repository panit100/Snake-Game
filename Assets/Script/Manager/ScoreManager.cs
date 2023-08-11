using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}

    int score = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highScoreText;

    void Awake() 
    {
        Instance = this;
    }

    void Start()
    {
        SetHighScoreText();
    }

    void UpdateScore()
    {
        scoreText.text = $"{score}";
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    public int GetScore()
    {
        return score;
    }

    void SetHighScoreText()
    {
        var tempHighScore = PlayerPrefs.GetInt(GameManager.HIGHSCORE,0);
        highScoreText.text = $"{tempHighScore}"; 
    }
}
