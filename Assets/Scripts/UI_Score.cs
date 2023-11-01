using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour
{
    ScoreManager scoreManager;

    Text currentText;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.OnUpdateScore += UpdateScore;
    }

    public void UpdateScore(int score)
    {
        currentText.text = score.ToString();
    }
}
