using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JsonLoadTest : MonoBehaviour
{

    NewsReader.NewsInfo NewsInfo;
    [SerializeField] Image _image;
    [SerializeField] GameObject go;
    Material material;

    // Start is called before the first frame update
    void Start()
    {

        NewsInfo = NewsReader.LoadNews(5);

        Debug.Log(NewsInfo.id);
        Debug.Log(NewsInfo.text);
        for (int i = 0; NewsInfo.explanations.Length > i; i++)
        {
            Debug.Log(NewsInfo.explanations[i]);
        }
        Debug.Log(NewsInfo.sprite[0].name);
        _image.sprite = NewsInfo.sprite[0];

        go.GetComponent<Renderer>().material.SetTexture("_MainTex", NewsInfo.sprite[0].texture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
