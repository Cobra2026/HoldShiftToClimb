using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;

    private bool isMoving;
    private Vector3 lastPlatformPosition;

    void Start()
    {
        transform.position = points[startingPoint].position;
        lastPlatformPosition = transform.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        Vector3 newPosition = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);

        Vector3 platformDelta = newPosition - transform.position;


        transform.position = newPosition;

        lastPlatformPosition = transform.position;
    }
}
