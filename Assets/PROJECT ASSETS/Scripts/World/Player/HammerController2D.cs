using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HammerController2D : MonoBehaviour
{
    private Rigidbody2D hammerRigidbody;
    private Vector2 lastMousePosition;
    private Camera mainCamera;
    private bool isClimbing = false;
    private bool isHolding = false;
    private HammerController2D objectXID;

    [SerializeField] private int mouseID;
    [SerializeField] private Transform objectX;
    [SerializeField] private float radius = 1.01f;
    [SerializeField] private Rigidbody2D objectXRigidbody;

    void Start()
    {
        hammerRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        objectXID = objectX.GetComponent<HammerController2D>();
    }

    void Update()
    {
        GravChecker();
        Vector2 direction = (Vector2)transform.position - (Vector2)objectX.position;
        float distance = direction.magnitude;

        HandleMouseInput();
        if (Input.GetMouseButton(mouseID))
        {
        CheckForMax();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Distance: " + distance);
        }
        if(objectXID.isHolding)
        {
            Debug.Log("ACTIVE: " + mouseID);
        }
    }


    private void HandleMouseInput()
    {
        float checkRadius = 0.1f;

        if (Input.GetMouseButtonDown(mouseID))
        {
            lastMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mouse down at: " + lastMousePosition);
        }

        if (Input.GetMouseButton(mouseID))
        {
            if (!objectXID.isHolding && objectXID.isClimbing)
            {
                Vector2 currentMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mouseDelta = currentMousePosition - lastMousePosition;

                Vector2 newPosition = hammerRigidbody.position + mouseDelta;

                hammerRigidbody.MovePosition(newPosition);
                lastMousePosition = currentMousePosition;
                isHolding = true;
            }
            else
            {
                isHolding = true;
            }
        }

        if (Input.GetMouseButtonUp(mouseID))
        {
            Collider2D hit = Physics2D.OverlapCircle(hammerRigidbody.position, checkRadius);
            Debug.Log("Mouse released. Checking for hit object: " + hit?.name);
            isHolding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climbable Static")
        {
            Debug.Log("check");
            isClimbing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climbable Static")
        {
            // Debug.Log("check");
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climbable Static")
        {
            isClimbing = false;
            // Debug.Log("uncheck");
        }
    }

    private void GravChecker()
    {
        if ((!isHolding && !isClimbing && !objectXID.isClimbing) || (objectXID.isHolding && isHolding) || 
        (!objectXID.isClimbing && isHolding) || (objectXID.isHolding && !isClimbing))
        {
            hammerRigidbody.gravityScale = 1;
            // Debug.Log("FALL");
        }
        else
        {
            hammerRigidbody.gravityScale = 0;
            hammerRigidbody.velocity = Vector2.zero;
            // Debug.Log("STOP");
        }
    }

    private void CheckForMax()
    {
        Vector2 direction = (Vector2)transform.position - (Vector2)objectX.transform.position;

        float distance = direction.magnitude;

        if (distance > radius)
        {
            Vector2 directionNormalized = direction.normalized;

            Vector2 newPosition = (Vector2)objectX.transform.position + directionNormalized * radius;

            transform.position = newPosition;
        }
    }
}