using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void EnableGravity()
    {
        rb.useGravity = true;
    }

    public void DisableGravity()
    {
        rb.useGravity = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.useGravity)
            {
                DisableGravity();
            }
            else
            {
                EnableGravity();
            }
        }
    }
}
