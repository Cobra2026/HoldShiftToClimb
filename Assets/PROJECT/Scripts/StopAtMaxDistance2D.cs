using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAtMaxDistance2D : MonoBehaviour
{
    public GameObject objectX;
    public GameObject objectY;
    public float maxDistance = 2f;
    public float currentDistance { get; private set; }

    private DistanceJoint2D distanceJoint;

    void Start()
    {

        distanceJoint = objectX.AddComponent<DistanceJoint2D>();
        distanceJoint.connectedBody = objectY.GetComponent<Rigidbody2D>();

        distanceJoint.autoConfigureDistance = false;
        distanceJoint.distance = maxDistance;
        distanceJoint.maxDistanceOnly = true;
    }

    void Update()
    {
        float currentDistance = Vector2.Distance(objectX.transform.position, objectY.transform.position);

        if (currentDistance >= maxDistance)
        {
            StopMovement(objectX);
            StopMovement(objectY);
        }
    }

    void StopMovement(GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }
    }
}
