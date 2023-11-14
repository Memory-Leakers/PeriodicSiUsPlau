using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    private NewsBehaviour _newsBehaviour;
    private Animator _animator;
    private States states = States.UNSELECTED;
    public enum States
    {
        UNSELECTED,
        SELECTED,
        SENT,
        RECEIVED,
    }
    DragObjectManager dragObjectManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        _newsBehaviour = gameObject.GetComponent<NewsBehaviour>();        
        dragObjectManager = GameObject.FindGameObjectWithTag("Picture Manager").GetComponent<DragObjectManager>();

        dragObjectManager.onPictureEnter += () => { Debug.Log("Hola"); states = States.SELECTED; };
        dragObjectManager.onPictureExit += () => { states = States.UNSELECTED; };
    }


    [ContextMenu("Send")]
    public void Send()
    {
        Debug.Log("ESTADO");
        Debug.Log(states);
        if(states == States.SELECTED)
        _animator.SetTrigger("NewspaperOut");
        
        //_newsBehaviour.GetNextNews();
    }

    [ContextMenu("Recieve")]
    public void Receive ()
    {
        if (states == States.SENT)
        _animator.SetTrigger("NewspaperIn");
    }

    public void UpdateNews()
    {
        _newsBehaviour.UpdateNewsData();
    }

    public void ChangeState(States state)
    {
        states = state;
    }

}

