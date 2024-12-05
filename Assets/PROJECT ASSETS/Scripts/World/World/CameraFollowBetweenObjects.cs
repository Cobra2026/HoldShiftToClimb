using UnityEngine;

public class CameraFollowBetweenObjects : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, 1f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    [SerializeField] private Transform target;

    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
    
    // [SerializeField] private Transform objectA;
    // [SerializeField] private Transform objectB;
    // [SerializeField] private float smoothSpeed = 0.125f;
    // [SerializeField] private Vector3 offset;

    // void Update()
    // {
    //     if (objectA == null || objectB == null) return;

    //     Vector3 midpoint = (objectA.position + objectB.position) / 2;

    //     Vector3 desiredPosition = midpoint + offset;

    //     Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

    //     transform.position = smoothedPosition;
    // }
}
