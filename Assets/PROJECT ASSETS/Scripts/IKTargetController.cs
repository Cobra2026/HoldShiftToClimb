using UnityEngine;

public class IKTargetController : MonoBehaviour
{
    public Transform shoulder;
    public float upperArmLength = 1.0f;
    public float forearmLength = 1.0f;
    public float minDistance = 0.1f;

    void Update()
    {
        float armLength = upperArmLength + forearmLength;
        Vector3 shoulderToTarget = transform.position - shoulder.position;

        if (shoulderToTarget.magnitude < minDistance)
        {
            transform.position = shoulder.position + shoulderToTarget.normalized * minDistance;
        }
        else if (shoulderToTarget.magnitude > armLength)
        {
            transform.position = shoulder.position + shoulderToTarget.normalized * armLength;
        }
    }
}
