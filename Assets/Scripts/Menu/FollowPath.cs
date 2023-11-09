using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{


    [SerializeField]Transform[] pathPoints;
    [SerializeField]float movementSpeed = 1.0f;
    
    Vector3 cameraPosition;
    int pathIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = pathPoints[pathIndex].position;
        cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pathIndex >= pathPoints.Length) { pathIndex = pathPoints.Length - 1; }

        Vector3 currentPosition = gameObject.transform.position;

        Vector3 nextPosition = pathPoints[pathIndex].position;

        Vector3 interpolatedPosition = Vector3.Lerp(currentPosition, nextPosition, movementSpeed * Time.deltaTime);

        gameObject.transform.position = interpolatedPosition;

        if (gameObject.transform.position == pathPoints[pathIndex].position)
        {
            pathIndex++;
        }

    }
}
