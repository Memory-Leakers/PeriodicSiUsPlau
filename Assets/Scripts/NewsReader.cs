using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public static class NewsReader
{

    public struct NewsInfo
    {

        public int id;
        public Sprite[] sprite;
        public string[] spritePreLoad;
        public int result;
        public string title;
        public string text;
        public string[] explanations;
        public int[] indexActivated;
    }

    static NewsInfo currentInfo;

    static string CreateFileLocation(int id)
    {
        string pathToJson = Application.dataPath + Path.AltDirectorySeparatorChar + "/Json/News" + id.ToString() + ".json";

        return pathToJson;  
    }

    public static NewsInfo LoadNews(int NewsIdToLoad)
    {

        string json = string.Empty;

        StreamReader jsonReader = new StreamReader(CreateFileLocation(NewsIdToLoad));

        json = jsonReader.ReadToEnd();

        // Get rid of the StreamReader object.
        jsonReader.Dispose();

        NewsInfo NewsTobeLoaded = new NewsInfo();

        NewsTobeLoaded = JsonUtility.FromJson<NewsInfo>(json);

        ConvertSpritePathToSprite(ref NewsTobeLoaded);

        SaveInfoIntoCurrentInfo(NewsTobeLoaded);

        return GetNewsCurrentInfo();
    }

    private static void ConvertSpritePathToSprite(ref NewsInfo NewsTobeLoaded)
    {
        NewsTobeLoaded.sprite = new Sprite[NewsTobeLoaded.spritePreLoad.Length];

        for (int i = 0; i < NewsTobeLoaded.spritePreLoad.Length; i++)
        {
            NewsTobeLoaded.sprite[i] = Resources.Load<Sprite>(NewsTobeLoaded.spritePreLoad[i]);
        }
    } 

    public static NewsInfo GetNewsCurrentInfo()
    {
        return currentInfo;
    }
    private static void SaveInfoIntoCurrentInfo(NewsInfo NewsTobeLoaded)
    {   
        currentInfo.id = NewsTobeLoaded.id;
        currentInfo.sprite = NewsTobeLoaded.sprite;
        currentInfo.spritePreLoad = NewsTobeLoaded.spritePreLoad;
        currentInfo.title = NewsTobeLoaded.title;
        currentInfo.text = NewsTobeLoaded.text;
        currentInfo.explanations = NewsTobeLoaded.explanations;
        currentInfo.result = NewsTobeLoaded.result;
        currentInfo.indexActivated = NewsTobeLoaded.indexActivated;
    }

    
}

//string temp = json;

//byte[] bytes = Encoding.UTF32.GetBytes(temp);
//temp = Encoding.UTF32.GetString(bytes);
//json = temp;