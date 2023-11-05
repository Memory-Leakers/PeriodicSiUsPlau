using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private Newspaper _newspaper;
    [SerializeField] private GameManager _gameManager;

    [SerializeField] private Material _picture;
    [SerializeField] private TextMeshPro _text;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        //Just for testing
        if (Input.GetKeyUp(KeyCode.D))
        {
            Send();
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Receive();
        }
    }

    void UpdateLetter(string text, int value, Texture texture)
    {
        _text.text = text;
        _picture.SetTexture(0, texture);
        
        _gameManager.AddScore(value);
    }

    public void Send()
    {
        _animator.SetTrigger("LetterOut");

        _newspaper.Receive();
    }

    public void Receive()
    {
        _animator.SetTrigger("LetterIn");

    }
}
