using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    float currentTime = 0;
    bool isPaused = false;
    
    private void Update()
    {
        if (isPaused)
            return;

        currentTime += Time.deltaTime;
    }

    public void ResetTime()
    {
        currentTime = 0;
    }

    // Current time in Seconds
    public int GetTime()
    {
        return (int)(currentTime * 0.001f);
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }

    public bool IsPaused()
    {
        return isPaused;
    }
}
