using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _offset;

    private float _zCoord;

    private bool _picked = false;

    [SerializeField, Range(0.0f, 20.0f), Tooltip("The smaller, the slower")]
    private float _lerpInterval = 15.0f;

    [SerializeField, Tooltip("X: height when object has been piked \nY: height when object has been drop")]
    private Vector2 _Ypos = new(0.5f, 0.15f);

    private bool _interactible = true;

    private void OnMouseDown()
    {
        if (!_interactible)
            return;

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
            transform.position = Vector3.Lerp(transform.position, GetMouseWorldPos() + _offset, _lerpInterval * Time.deltaTime);
        else
        {
            transform.position = Vector3.Lerp(transform.position,
                new(transform.position.x, _Ypos.y, transform.position.z), _lerpInterval * Time.deltaTime);
        }
    }
}
