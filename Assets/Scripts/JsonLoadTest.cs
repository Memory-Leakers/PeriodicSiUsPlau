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

        NewsInfo = NewsReader.LoadNews(1);

        Debug.Log(NewsInfo.id);
        Debug.Log(NewsInfo.text);
        for (int i = 0; NewsInfo.explanations.Length > i; i++)
        {
            Debug.Log(NewsInfo.explanations[i]);
        }
        Debug.Log(NewsInfo.sprite[1].name);
        _image.sprite = NewsInfo.sprite[1];

        go.GetComponent<Renderer>().material.SetTexture("_MainTex", NewsInfo.sprite[1].texture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
