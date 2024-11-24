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
    private bool isGravity = true;

    [SerializeField] private int mouseID;
    [SerializeField] private Transform objectX;
    [SerializeField] private float radius = 1.01f;
    [SerializeField] private Rigidbody2D objectXRigidbody;

    void Start()
    {
        hammerRigidbody = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        isGravity = true;
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
            isHolding = true;
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
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climbable Static")
        {
            Debug.Log("check");
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climbable Static")
        {
            isClimbing = false;
            Debug.Log("uncheck");
        }
    }

    private void GravChecker()
    {
        if (!isHolding && !isClimbing)
        {
            isGravity = true;
            hammerRigidbody.gravityScale = 1;
        }
        else
        {
            isGravity = false;
            hammerRigidbody.gravityScale = 0;
            hammerRigidbody.velocity = Vector2.zero;
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