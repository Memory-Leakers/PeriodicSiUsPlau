using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EndScreen : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;   
    }

    [ContextMenu("ShowScreen")]
    public void ShowScreen()
    {
        animator.enabled = true;
    }

    public void PlayAgain()
    {

    }

    public void MainMenu()
    {

    }
}
