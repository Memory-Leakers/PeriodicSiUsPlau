using System;
using UnityEngine;

public class DragObjectManager : MonoBehaviour
{
    [SerializeField] private Transform _pictureSelectAreaLeftLimit;
    [SerializeField] private Transform _pictureSelectAreaRightLimit;
    [SerializeField] private Transform _pictureSelectAreaTopLimit;
    [SerializeField] private Transform _pictureSelectAreaBottomLimit;

    [Space, SerializeField, Tooltip("JUST FOR CHECK \nX: left limit \nY: right limit \nZ: top limit \nW: bottom limit")] 
    private Vector4 _pictureSelectArea;

    [Space, SerializeField] private Material[] _materials = new Material[3];

    private bool _lastAreaCheck = false;

    public bool selected = false;

    public Action onPictureEnter;

    public Action onPictureExit;

    public Action onReset;

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

    /// <param name="textures">3 pictures</param>
    public void SetNewPictures(Texture[] textures)
    {
        for(int i = 0; i < _materials.Length; i++)
        {
            _materials[i].mainTexture = textures[i];
        }
    }

    public void ResetPictures() 
    {
        onPictureExit?.Invoke();
        onReset?.Invoke();
        
        selected = false;
    }
}
