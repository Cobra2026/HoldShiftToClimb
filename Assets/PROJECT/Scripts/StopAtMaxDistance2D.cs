using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAtMaxDistance2D : MonoBehaviour
{
    public GameObject objectX;  // Object being dragged or moved
    public GameObject objectY;  // Connected object
    public float maxDistance = 2f;  // Maximum allowed distance between Object X and Y
    public float currentDistance { get; private set; }

    private DistanceJoint2D distanceJoint;

    void Start()
    {
        // Attach a Distance Joint 2D to Object X
        distanceJoint = objectX.AddComponent<DistanceJoint2D>();
        distanceJoint.connectedBody = objectY.GetComponent<Rigidbody2D>();

        // Set the maximum distance in the Distance Joint
        distanceJoint.autoConfigureDistance = false;
        distanceJoint.distance = maxDistance;
        distanceJoint.maxDistanceOnly = true;
    }

    void Update()
    {
        // Calculate the current distance between Object X and Object Y
        float currentDistance = Vector2.Distance(objectX.transform.position, objectY.transform.position);

        // Check if the distance exceeds the maximum allowed distance
        if (currentDistance >= maxDistance)
        {
            // Stop movement for both Object X and Object Y
            StopMovement(objectX);
            StopMovement(objectY);
        }
    }

    // Function to stop an object's movement by setting velocity to zero
    void StopMovement(GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;  // Stop linear movement
            rb.angularVelocity = 0f;  // Stop any rotation or spin
        }
    }
}
