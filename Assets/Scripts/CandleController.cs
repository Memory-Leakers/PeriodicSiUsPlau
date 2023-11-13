using UnityEngine;

public class CandleController : MonoBehaviour
{
    [SerializeField, Range(0f, 1.0f), Tooltip("In seconds")]
    private float _value = 0.0f;
    [SerializeField, Tooltip("In local position \nX: Top \nY: Buttom")]
    private Vector2 _fireHeight = new(0.5f, 2.0f);

    [SerializeField] private Transform _firePivotTrans;
    [SerializeField] private ParticleSystem _firePrticle;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    private TimeManager _timeManager;

    public float Value
    {
        get => _value;
        set => _value = value < 0 ? 0 : value > 1 ? 1 : value;
    }

    void Start()
    {
        _timeManager = FindObjectOfType<TimeManager>();
        if (_timeManager != null)
        {
            _timeManager.onValueChange += OnValueChange;
            _timeManager.onTimeOut += OnTimeOut;
        }

        _skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    private void OnValueChange(float value)
    {
        Value = CalculateCandleRatioValue(_timeManager.MaxTime, value);

        _firePivotTrans.localPosition= new
            (_firePivotTrans.localPosition.x,
            _fireHeight.x - (_fireHeight.x - _fireHeight.y) * Value,
            _firePivotTrans.localPosition.z);

        _skinnedMeshRenderer.SetBlendShapeWeight(0, Value * 100);
    }

    private void OnTimeOut()
    {

    }

    private float CalculateCandleRatioValue(float totalTime, float currentTime)
    {
        return currentTime / totalTime;
    }
}
