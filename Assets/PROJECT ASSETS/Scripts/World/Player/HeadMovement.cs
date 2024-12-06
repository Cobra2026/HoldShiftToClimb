using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public GameObject handL, handR, headP;
    public float maxRotationOffset = 45f;
    private float originalAngle;

    void Start()
    {
        originalAngle = headP.transform.eulerAngles.z;
    }

    void Update()
    {
        headP.transform.position = Vector3.Lerp(handL.transform.position, handR.transform.position, 0.5f);

        Vector2 direction = handR.transform.position - handL.transform.position;

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        float targetAngled = targetAngle + 90.0f;

        float clampedAngle = Mathf.Clamp(targetAngled, originalAngle - maxRotationOffset, originalAngle + maxRotationOffset);

        headP.transform.rotation = Quaternion.Euler(0, 0, clampedAngle);
    }
}