using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedNewsManager : MonoBehaviour
{
    [SerializeField]
    int firstNews = 10;

    static List<int> unlockedIDs = new List<int>();

    static List<int> mainPool = new List<int>();

    private void Awake()
    {
        // Add IDs for first X news (0 to firstNews)
        if (unlockedIDs.Count == 0)
        {
            for (int i = 0; i < firstNews; ++i)
                unlockedIDs.Add(i);
        }
        ResetMainPool();
    }

    //DEBUG CODE-------------------
    
    [ContextMenu("PrintUnlocked")]
    void PrintUnlockedIDs()
    {
        string ids = "";
        foreach (var id in unlockedIDs)
            ids += id.ToString() + " ";

        Debug.Log("UnlockedIDs: " + ids + "\n Total Count: " + unlockedIDs.Count);
    }

    [ContextMenu("PrintMain")]
    void PrintMainPool()
    {
        string ids = "";
        foreach (var id in mainPool)
            ids += id.ToString() + " ";

        Debug.Log("MainPool: " + ids + "\n Total Count: " + mainPool.Count);
    }

    //---------------------------------------------------


    public void UnlockNews(List<int> addedNews)
    {
        for (int i = 0; i < addedNews.Count; ++i)
        {
            // Make sure we are not duplicating IDs in UnlockedIDs.
            if (unlockedIDs.Contains(addedNews[i]))
                continue;
            unlockedIDs.Add(addedNews[i]);
            mainPool.Add(addedNews[i]);
        }
    }

    public List<int> GetGameNews(int amount)
    {
        List<int> gameNews;
        if (amount > mainPool.Count)
        {
            // If we are asking for more news than we have in mainPool
            // Get last few news, reset the pool and complete the needed amount with random non-duplicated news-
            gameNews = mainPool;
            ResetMainPool();
            RandomizeList(gameNews);
            int neededAmount = amount - gameNews.Count;
            while (neededAmount != 0)
            {
                int randomNum = Random.Range(0, mainPool.Count);
                if (!gameNews.Contains(mainPool[randomNum]))
                {
                    gameNews.Add(mainPool[randomNum]);
                    --neededAmount;
                }
            }
        }
        else
        {
            gameNews = mainPool;
            RandomizeList(gameNews);
        }

        return gameNews.GetRange(0,amount);
    }

    // Removes a News ID from the Main Pool, so it wont be playable until Main Pool is remade.
    public void RemoveNews(int ID)
    {
        mainPool.Remove(ID);
        int a= unlockedIDs.Count;
    }

    void RandomizeList(List<int> list)
    {
        for (int i = 0; i < list.Count; ++i)
        {
            int randomNum = Random.Range(0, list.Count);
            int temp = list[i];
            list[i] = list[randomNum];
            list[randomNum] = temp;
        }
    }

    void ResetMainPool()
    {
        mainPool.Clear();
        mainPool.AddRange(unlockedIDs);
    }

}
