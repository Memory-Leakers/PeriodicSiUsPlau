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
    [SerializeField] TMP_Text _titleText;
    [SerializeField] Transform[] pictures;
    Vector3[] picturesPosInStart;
    GameManager _gameManager;
    Letter letter;
    NewsReader.NewsInfo info;
    bool hasInfo = false;
    DragObjectManager dragObjectManager;
    Texture[] newsInfoText;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        letter = FindObjectOfType<Letter>();
        dragObjectManager = FindObjectOfType<DragObjectManager>();

        picturesPosInStart = new Vector3[pictures.Length];

        for (int i = 0; i < pictures.Length; i++)
        {
            picturesPosInStart[i] = pictures[i].localPosition;
        }
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

        newsInfoText = new Texture[info.sprite.Length];

        for (int i = 0; i < info.sprite.Length; i++)
        {
            newsInfoText[i] = info.sprite[i].texture;
        }

        dragObjectManager.SetNewPictures(newsInfoText);

        _newsText.text = info.text;
        _titleText.text = info.title;

    }

    public void ReceiveNews()
    {
        for (int i = 0; i < pictures.Length; i++)
        {
            pictures[i].localPosition = picturesPosInStart[i];
        }

        dragObjectManager.ResetPictures();
    }
}
