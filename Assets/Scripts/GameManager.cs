using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreManager score;

    // Current number of news in a game
    public int newsPerGame = 10;


    int currentNewsIndex = -1;
    [SerializeField]
    List<int> unusedNews;

    UnlockedNewsManager newsManager;

    NewsReader.NewsInfo currentNewsInfo;

    NewsBehaviour newsBehaviour;

    

    private void Awake()
    {
        newsManager = FindObjectOfType<UnlockedNewsManager>();
        score = FindObjectOfType<ScoreManager>();
        
    }

    private void Start()
    {
        // Done on Start instead of Awake becouse we need UnlockedNewsManager awake to happen before this.
        ResetUnusedNews();

        newsBehaviour = FindObjectOfType<NewsBehaviour>();
        newsBehaviour.UpdateNewsData();

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

        if (currentNewsIndex == unusedNews.Count-1)
        {
            // We finish the game because we did all the news.
        }

        // Do the process of selecting the next news.
        currentNewsInfo = NewsReader.LoadNews(unusedNews[++currentNewsIndex]+1);

        return currentNewsInfo;
    }
    
    public void AddScore(int num)
    {
        score.AddScore(num);
    }

    void ResetUnusedNews()
    {
        unusedNews = newsManager.GetGameNews(newsPerGame);

        Debug.Log(unusedNews.Count);
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
