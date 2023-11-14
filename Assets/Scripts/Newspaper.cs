using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    private NewsBehaviour _newsBehaviour;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _newsBehaviour = gameObject.GetComponent<NewsBehaviour>();        
    }


    [ContextMenu("Send")]
    public void Send()
    {
        _animator.SetTrigger("NewspaperOut");

        //_newsBehaviour.GetNextNews();
    }

    [ContextMenu("Recieve")]
    public void Receive ()
    {
        _animator.SetTrigger("NewspaperIn");
    }
}
