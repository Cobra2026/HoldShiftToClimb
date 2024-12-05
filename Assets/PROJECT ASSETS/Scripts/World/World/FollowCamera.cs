using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private float FollowSpeed = 2f;
    [SerializeField] private RectTransform target;
    [SerializeField] private float zValue;

    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, zValue);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}