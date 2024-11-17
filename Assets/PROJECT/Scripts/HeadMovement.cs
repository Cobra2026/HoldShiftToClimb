using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovement : MonoBehaviour
{
    public GameObject handL, handR;

    public void Update()
    {
        transform.position = Vector3.Lerp(handL.transform.position, handR.transform.position, 0.5f);
    }
}