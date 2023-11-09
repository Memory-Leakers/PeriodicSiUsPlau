using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    [SerializeField]Transform[] pathPoints;
    [SerializeField]float movementSpeed = 1.0f;
    int pathIndex = 0;

    /*
     * Sx = U*cos(angle)*t;
       Sy = U*sin(angle)*t - 0.5*g*t^2;
     */
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = pathPoints[pathIndex].position;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, pathPoints[pathIndex].position, movementSpeed * Time.deltaTime);

        if (gameObject.transform.position == pathPoints[pathIndex].position)
        {
            pathIndex++;
        }

    }
}
