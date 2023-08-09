using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {get; private set;}

    int score = 0;

    public TMP_Text scoreText;

    private void Awake() 
    {
        Instance = this;
    }

    void UpdateScore()
    {
        scoreText.text = $"Score : {score}";
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }
}
