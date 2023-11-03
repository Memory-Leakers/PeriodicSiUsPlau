using System;
using UnityEngine;

public class DragObjectManager : MonoBehaviour
{
    [SerializeField] private Transform _pictureSelectAreaLeftLimit;
    [SerializeField] private Transform _pictureSelectAreaRightLimit;
    [SerializeField] private Transform _pictureSelectAreaTopLimit;
    [SerializeField] private Transform _pictureSelectAreaBottomLimit;

    [Space, SerializeField, Tooltip("X: left limit \nY: right limit \nZ: top limit \nW: bottom limit")] private Vector4 _pictureSelectArea;

    private bool _lastAreaCheck = false;

    public Action onPictureEnter;

    public Action onPictureExit;

    void Start()
    {
        _pictureSelectArea.x = _pictureSelectAreaLeftLimit.position.x;
        _pictureSelectArea.y = _pictureSelectAreaRightLimit.position.x;
        _pictureSelectArea.z = _pictureSelectAreaTopLimit.position.z;
        _pictureSelectArea.w = _pictureSelectAreaBottomLimit.position.z;
    }

    public bool CheckInArea(Vector2 pos)
    {
        if (pos.x >= _pictureSelectArea.x && pos.x <= _pictureSelectArea.y
            && pos.y <= _pictureSelectArea.z && pos.y >= _pictureSelectArea.w)
        {

            if (!_lastAreaCheck)
            {
                _lastAreaCheck = true;
                onPictureEnter?.Invoke();
            }

            return true;
        }

        if (_lastAreaCheck)
        {
            _lastAreaCheck = false;
            onPictureExit?.Invoke();
        }

        return false;
    }
}
