using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField] private Newspaper _newspaper;

    [SerializeField] private Material _picture;
    [SerializeField] private TextMeshPro _text;
    
    private Animator _animator;
    private GameManager _gameManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
    }

    public void UpdateLetter(string text, int value, Texture texture)
    {
        _text.text = text;
        _picture.SetTexture("_MainTex", texture);
        
        _gameManager.AddScore(value);
    }

    [ContextMenu("Send")]
    public void Send()
    {
        _animator.SetTrigger("LetterOut");

        _newspaper.Receive();
    }

    [ContextMenu("Receive")]
    public void Receive()
    {
        _animator.SetTrigger("LetterIn");

    }
}
