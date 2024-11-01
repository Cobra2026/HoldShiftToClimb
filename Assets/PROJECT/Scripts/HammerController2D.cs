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

    [SerializeField] private int mouseID;
    [SerializeField] private Transform objectX;
    [SerializeField] private float radius = 1.01f;
    [SerializeField] private Rigidbody2D objectXRigidbody;

    void Start()
    {
        hammerRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        GravityToggle();
        Vector2 direction = (Vector2)transform.position - (Vector2)objectX.position;
        float distance = direction.magnitude;

        if (Input.GetMouseButton(mouseID))
        {
        HandleMouseInput();
        CheckForMax();
        // if (distance >= radius)
        // {
        //     Vector2 directionNormalized = direction.normalized;
        //     // Vector2 newPosition = (Vector2)objectX.position + directionNormalized * radius;
                        
        //     Debug.Log( "Distance: " + distance);
        //     hammerRigidbody.MovePosition((Vector2)objectX.position + directionNormalized * radius);
        // }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Distance: " + distance);
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
            Vector2 currentMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseDelta = currentMousePosition - lastMousePosition;

            Vector2 newPosition = hammerRigidbody.position + mouseDelta;

            hammerRigidbody.MovePosition(newPosition);
            lastMousePosition = currentMousePosition;
        }

        if (Input.GetMouseButtonUp(mouseID))
        {
            Collider2D hit = Physics2D.OverlapCircle(hammerRigidbody.position, checkRadius);
            Debug.Log("Mouse released. Checking for hit object: " + hit?.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Climbable Platform")
        {
            Debug.Log("check");
            isClimbing = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Climbable Platform")
        {
            Debug.Log("check");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Climbable Platform")
        {
            isClimbing = false;
            Debug.Log("uncheck");
        }
    }

    private void GravityToggle()
    {
            if(!isClimbing)
            {
                hammerRigidbody.gravityScale = 1;
            }

            else if (isClimbing)
            {
                hammerRigidbody.gravityScale = 0;
                hammerRigidbody.velocity = Vector2.zero;
            }
    }

    private void CheckForMax()
    {
        Vector2 direction = (Vector2)transform.position - (Vector2)objectX.position;

        float distance = direction.magnitude;

        if (distance > radius)
        {
            Vector2 directionNormalized = direction.normalized;

            Vector2 newPosition = (Vector2)objectX.position + directionNormalized * radius;

            transform.position = newPosition;
        }
    }
}