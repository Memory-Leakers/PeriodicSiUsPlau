using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreManager score;

    // Current number of news in a game
    public int newsPerGame = 10;


    int currentNews = 0;
    [SerializeField]
    List<int> unusedNews;

    UnlockedNewsManager newsManager;

    private void Awake()
    {
        newsManager = FindObjectOfType<UnlockedNewsManager>();
        score = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        // Done on Start instead of Awake becouse we need UnlockedNewsManager awake to happen before this.
        ResetUnusedNews();
    }

    // TODO: Change to return NewsInfo when created
    public void NextNews()
    {
        // Do the process of selecting the next news.

        ++currentNews;
    }
    
    public void AddScore(int num)
    {
        score.AddScore(num);
    }

    void ResetUnusedNews()
    {
        unusedNews = newsManager.GetGameNews(newsPerGame);
    }

}
