using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsBehaviour : MonoBehaviour
{
    // News datas
    private string _currentNews;
    private Dictionary<Sprite, string> _newsAnswers; // sprite & explanation of each answer
    private int _currentAnswer;

    // private GameManager _gameManager
    [SerializeField] TMP_Text _newsText;
    GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void UpdateNewsData()
    {
        // Send data to Letter
        // Letter.UpdateLetter(_answersExplanations[_currentAnswer], _newsSprites[_currentAnswer], points);

        // TODO: Calculate if the current answer is correct or not.
        NewsReader.NewsInfo info = _gameManager.NextNews();
        // Get new data from GameManager
        // var data = _gameManager.GetNextNews();
        _newsText.text = info.text;
    }
}
