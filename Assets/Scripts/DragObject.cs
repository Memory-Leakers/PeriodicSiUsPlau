using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 _offset;

    private bool _picked = false;

    private bool _inSelectArea = false;

    private bool _interactible = true;

    [SerializeField, Range(0.0f, 20.0f), Tooltip("The smaller, the slower")]
    private float _lerpInterval = 15.0f;

    [SerializeField, Tooltip("X: height when object has been piked \nY: height when object has been drop")]
    private Vector2 _Ypos = new(0.5f, 0.15f);

    // Newspaper slect area pivot
    private Transform _pivot;

    private DragObjectManager _manager;

    private void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("Picture Manager").GetComponent<DragObjectManager>();
        _pivot = GameObject.FindGameObjectWithTag("Picture Pivot").GetComponent<Transform>();
    }

    private void OnMouseDown()
    {
        if (!_interactible)
            return;

        // pick immediadly
        transform.position = new(transform.position.x, _Ypos.x, transform.position.z);

        _offset = transform.position - GetMouseWorldPos();

        _picked = true;
    }

    private void OnMouseUp()
    {
        _picked = false;

        if (_inSelectArea)
        {
           // selected
        }
    }

    private Vector3 GetMouseWorldPos()
    {       
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void Update()
    {
        if (_picked)
            transform.position = Vector3.Lerp(transform.position, GetMouseWorldPos() + _offset, _lerpInterval * Time.deltaTime);
        else
        {
            if (!_inSelectArea)
                transform.position = Vector3.Lerp(transform.position,
                    new(transform.position.x, _Ypos.y, transform.position.z), _lerpInterval * Time.deltaTime);

            else
                transform.position = Vector3.Lerp(transform.position,
                    new(_pivot.position.x, _Ypos.y, _pivot.position.z), _lerpInterval * Time.deltaTime);
        }

        _inSelectArea = _manager.CheckInArea(new(transform.position.x, transform.position.z));
    }
}
