using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
[SerializeField] private GameObject hand;
void Update()
{
    if (hand != null)
    {
        transform.position = Vector3.Lerp(transform.position, hand.transform.position, Time.deltaTime * 10f);
    }
}

}
