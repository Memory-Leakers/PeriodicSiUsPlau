using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _offset;

    private float _zCoord;

    private bool _picked = false;

    [SerializeField, Range(0.0f, 1.0f), Tooltip("The smaller, the smoother")]
    private float _lerpInterval = 0.1f;

    [SerializeField, Tooltip("X: height when object has been piked \nY: height when object has been drop")]
    private Vector2 _Ypos = new(0.5f, 0.15f);

    private void OnMouseDown()
    {
        transform.position = new(transform.position.x, _Ypos.x, transform.position.z);

        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        _offset = transform.position - GetMouseWorldPos();

        _picked = true;
    }

    private void OnMouseUp()
    {
        _picked = false;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = _zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void Update()
    {
        if (_picked)
            transform.position = Vector3.Lerp(transform.position, GetMouseWorldPos() + _offset, _lerpInterval);
        else
        {
            transform.position = Vector3.Lerp(transform.position,
                new(transform.position.x, _Ypos.y, transform.position.z), _lerpInterval * 0.5f);
        }
    }
}
