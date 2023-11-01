using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    ScoreManager score;

    // Current number of news in news pool
    public int maxNews = 10;


    int currentNews = 0;
    [SerializeField]
    List<int> unusedNews;

    private void Awake()
    {
        score = FindObjectOfType<ScoreManager>();
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
        currentNews = 0;
        unusedNews.Clear();
        unusedNews = new List<int>(new int[maxNews]);
        for (int i = 0; i < maxNews; ++i)
        {
            unusedNews[i] = i;
        }

        for (int i = 0; i < maxNews; ++i)
        {
            int randomNum = Random.Range(0, maxNews);
            int temp = unusedNews[i];
            unusedNews[i] = unusedNews[randomNum];
            unusedNews[randomNum] = temp;
        }
    }

}
