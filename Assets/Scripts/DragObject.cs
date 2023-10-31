using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _offset;

    private float _zCoord;

    [SerializeField]
    private Vector2 _Ypos = new Vector2(0.5f, 0.15f);

    private void OnMouseDown()
    {
        transform.position = new(transform.position.x, _Ypos.x, transform.position.z);

        _zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

        _offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseUp()
    {
        transform.position = new(transform.position.x, _Ypos.y, transform.position.z);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = _zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + _offset;
    }
}
