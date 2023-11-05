using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreManager score;

    // Current number of news in a game
    public int newsPerGame = 10;


    int currentNewsIndex = 0;
    [SerializeField]
    List<int> unusedNews;

    UnlockedNewsManager newsManager;

    NewsReader.NewsInfo currentNewsInfo;

    private void Awake()
    {
        newsManager = FindObjectOfType<UnlockedNewsManager>();
        score = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        // Done on Start instead of Awake becouse we need UnlockedNewsManager awake to happen before this.
        ResetUnusedNews();
        // DEBUG-------------------------------
        NextNews(false);

    }

    /// <summary>
    /// Returns next news NewsInfo. Needs to know if the current news was answered correctly or not. If this is the first news, so no previous news was loaded, correctAnswer should be always false.
    /// </summary>
    /// <param name="rightAnswer"></param>
    /// <returns></returns>
    public NewsReader.NewsInfo NextNews(bool correctAnswer = false)
    {
        // If good response
        if (correctAnswer)
        {
            Debug.Log("Removing ID: " + currentNewsInfo.id);
            newsManager.RemoveNews(currentNewsInfo.id); // remove from main pool this news because it was correct.

            // unlock news for getting this news right.
            List<int> unlockedNews = new List<int>(currentNewsInfo.indexActivated);
            if (unlockedNews.Count != 0)
                newsManager.UnlockNews(unlockedNews);
        }

        // Do the process of selecting the next news.
        //currentNewsInfo = NewsReader.LoadNews(unusedNews[++currentNewsIndex]);
        // DEBUG------------------------------------------------------------
        currentNewsInfo = new NewsReader.NewsInfo();
        currentNewsInfo.indexActivated = new int[3] { Random.Range(31,100), Random.Range(31, 100), Random.Range(31, 100) };
        currentNewsInfo.id = unusedNews[currentNewsIndex++];

        // ---------------------------------------------------------------
        return currentNewsInfo;
    }
    
    public void AddScore(int num)
    {
        score.AddScore(num);
    }

    void ResetUnusedNews()
    {
        unusedNews = newsManager.GetGameNews(newsPerGame);
    }

    [ContextMenu("Correct")]
    void CorrectNews()
    {
        NextNews(true);
    }

    [ContextMenu("Incorrect")]
    void InCorrectNews()
    {
        NextNews(false);
    }
}
