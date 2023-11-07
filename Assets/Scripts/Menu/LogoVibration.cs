using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LogoVibration : MonoBehaviour
{

    Transform _transform;
    [SerializeField]float rotationSpeed = 5.0f;
    [SerializeField] int maxRotationAngle = 20;
    bool HasReachTheAngle = false;
    // Start is called before the first frame update
    void Start()
    {
        _transform = gameObject.GetComponent<Transform>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(_transform.rotation.eulerAngles.z < maxRotationAngle && _transform.rotation.eulerAngles.z > (maxRotationAngle-2))
        {
            HasReachTheAngle = true;
        }
        else if (_transform.rotation.eulerAngles.z < (360- maxRotationAngle) && _transform.rotation.eulerAngles.z > (360 - maxRotationAngle -2))
        {
            HasReachTheAngle = false;
        }

        if (!HasReachTheAngle)
        {
            _transform.Rotate(Vector3.forward * rotationSpeed *Time.deltaTime);
        }
        else
        {
            _transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }
        
    }
}
