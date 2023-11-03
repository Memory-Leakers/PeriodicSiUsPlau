using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentMultiplier = 1;

    [SerializeField]
    int currentScore = 0;

    public delegate void OnUpdateScoreHandler(int score);

    public event OnUpdateScoreHandler OnUpdateScore;

    // If score = 0, multiplier drops to 0. Else, multiplier +1
    public void AddScore(int score)
    {
        currentScore += score * currentMultiplier;

        if (score == 0)
            currentMultiplier =1;
        else
            currentMultiplier += 1;

        if (OnUpdateScore != null)
            OnUpdateScore(currentScore);
    }

    public int GetScore()
    {
        return currentScore;
    }

    [ContextMenu("Add100")]
    void Add100()
    {
        AddScore(100);
    }

    [ContextMenu("Add0")]
    void Add0()
    {
        AddScore(0);
    }
}
