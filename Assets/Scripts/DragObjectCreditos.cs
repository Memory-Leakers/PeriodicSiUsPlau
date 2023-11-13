using UnityEngine;

public class DragObjectCreditos : MonoBehaviour
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

    private Vector3 initialPos = Vector3.zero;

    private void Start()
    {
        initialPos = transform.position;
        
    }

    private void OnMouseDown()
    {
        if (!_interactible)
            return;

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

            transform.position = Vector3.Lerp(transform.position,
               new(initialPos.x, _Ypos.y, initialPos.z), _lerpInterval * Time.deltaTime);

        }
    }

}
