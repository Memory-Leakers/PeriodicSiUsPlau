using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Callback definitions
    public delegate void OnValueChange(float value);
    public delegate void OnTimeOut();

    // variables
    [SerializeField, Tooltip("In seconds")]
    private float _maxTime = 180;
    private float _currentTime = 0.0f;
    private bool _isPlaying = true;

    // attributes
    public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }

    // CallBacks
    public OnValueChange onValueChange;
    public OnTimeOut onTimeOut;

    private void Start()
    {
        onTimeOut += TimeOut;
    }

    private void Update()
    {
        if (!_isPlaying)
            return;

        _currentTime += Time.deltaTime;

        if (onValueChange != null)
            onValueChange.Invoke(1);

        if (_currentTime >= _maxTime && onTimeOut != null) 
            onTimeOut.Invoke();
    }

    public void ResetTime()
    {
        _currentTime = 0;
    }

    // Current time in Seconds
    public int GetTime()
    {
        return (int)(_currentTime * 0.001f);
    }

    private void TimeOut()
    {
        IsPlaying = false;
        ResetTime();
    }
}
