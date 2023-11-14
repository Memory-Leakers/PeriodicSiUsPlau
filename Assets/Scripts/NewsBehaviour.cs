using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsBehaviour : MonoBehaviour
{
    // News datas
    private string _currentNews;
    //private Dictionary<Sprite, string> _newsAnswers = new Dictionary<Sprite, string>(); // sprite & explanation of each answer
    private int _currentAnswer = -1;

    // private GameManager _gameManager
    [SerializeField] TMP_Text _newsText;
    GameManager _gameManager;
    Letter letter;
    NewsReader.NewsInfo info;
    bool hasInfo = false;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        letter = FindObjectOfType<Letter>();
    }

    public void UpdateNewsData()
    {
        int points = info.result == _currentAnswer ? 100 : 0;
       
        // Send data to Letter
        if (hasInfo)
        {
            letter.UpdateLetter(info.explanations[_currentAnswer], points, info.sprite[_currentAnswer].texture);
            letter.Receive();
        }

        info = _gameManager.NextNews(points == 100 ? true : false);
        hasInfo = true;
        _currentAnswer = 0;

        _newsText.text = info.text;

    }
}
