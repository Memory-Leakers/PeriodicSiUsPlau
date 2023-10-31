using System;
using System.Collections.Generic;
using UnityEngine;

public class NewsBehaviour : MonoBehaviour
{
    // News datas
    private string _currentNews;
    private List<Tuple<Sprite, string>> _newsAnswers; // sprite & explanation of each answer
    private int _currentAnswer;

    // private GameManager _gameManager;

    public void UpdateNewsData()
    {
        // Send data to Letter
        // Letter.UpdateLetter(_answersExplanations[_currentAnswer], _newsSprites[_currentAnswer], points);

        // Get new data from GameManager
        // var data = _gameManager.GetNextNews();
    }

}
