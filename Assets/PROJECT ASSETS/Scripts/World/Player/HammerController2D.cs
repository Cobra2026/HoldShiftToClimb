using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HammerController2D : MonoBehaviour
{
    private Rigidbody2D hammerRigidbody;
    private Vector2 lastMousePosition;
    private Vector2 previousPosition;
    private Camera mainCamera;
    public bool isClimbing, isClimbingStatic, isHolding, isClimbingMove, isBool = false;
    public HammerController2D objectXID;
    private Collider2D col;

    [SerializeField] private int mouseID;
    [SerializeField] private Transform objectX;
    [SerializeField] private float radius = 1.01f;
    [SerializeField] private Rigidbody2D objectXRigidbody;

    void Start()
    {
        hammerRigidbody = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        mainCamera = Camera.main;
        objectXID = objectX.GetComponent<HammerController2D>();

        col.isTrigger = true;
    }

    void Update()
    {
        GravChecker();
        Vector2 direction = (Vector2)transform.position - (Vector2)objectX.position;
        float distance = direction.magnitude;

        if (!isBool)
        {
        HandleMouseInput();
        }
        if (Input.GetMouseButton(mouseID))
        {
        CheckForMax();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("Distance: " + distance);
        }
        if(objectXID.isHolding)
        {
            // Debug.Log("ACTIVE: " + mouseID);
        }
    }

    private void HandleMouseInput()
    {
        float checkRadius = 0.1f;

        if (Input.GetMouseButtonDown(mouseID))
        {
            lastMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            // Debug.Log("Mouse down at: " + lastMousePosition);
            // Debug.Log("TestFail");
        }

        if (Input.GetMouseButton(mouseID))
        {
            if (!objectXID.isHolding && objectXID.isClimbing)
            {
                Vector2 currentMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mouseDelta = currentMousePosition - lastMousePosition;

                Vector2 newPosition = hammerRigidbody.position + mouseDelta;
                if(objectXID.isClimbingMove)
                {
                    // hammerRigidbody.MovePosition(newPosition);
                    lastMousePosition = currentMousePosition;
                    isHolding = true;
                    return;
                }
                hammerRigidbody.MovePosition(newPosition);
                lastMousePosition = currentMousePosition;
                isHolding = true;
            }
            else
            {
                isHolding = true;
                Debug.Log("TestFail");
            }
        }

        if (Input.GetMouseButtonUp(mouseID))
        {
            Collider2D hit = Physics2D.OverlapCircle(hammerRigidbody.position, checkRadius);
            // Debug.Log("Mouse released. Checking for hit object: " + hit?.name);
            isHolding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable Static"))
        {
            // Debug.Log("check");
            isClimbing = true;
        }
        if (collision.CompareTag("Climbable Move"))
        {
            isClimbing = true;
            previousPosition = collision.transform.position;
        }
        // if (collision.CompareTag("LASER"))
        // {
        //     StartCoroutine (TimeDelay());
        // }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable Static"))
        {
            isClimbing = true;
            isClimbingStatic = true;
            BlinkingPlatforms blinkingPlatform = collision.GetComponent<BlinkingPlatforms>();
        if (blinkingPlatform != null)
            {
                blinkingPlatform.isFalling = true;
            }
        }
        if (collision.CompareTag("Climbable Move"))
        {
            if (objectXID.isClimbingStatic)
            {
                CheckForMax();
            }
            // Debug.Log("check");
            isClimbing = true;
            Vector2 currentPlatformPosition = collision.transform.position;

            Vector2 deltaMovement = currentPlatformPosition - previousPosition;


            transform.position += (Vector3)deltaMovement;

            previousPosition = currentPlatformPosition;
            if (!objectXID.isClimbing)
            {
                objectXID.transform.position += (Vector3)deltaMovement;
            }
        }
        // if (collision.CompareTag("LASER"))
        // {
        //     StartCoroutine (TimeDelay());
        // }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable Static") || collision.CompareTag("Climbable Move"))
    {
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        bool stillClimbing = false;
        bool stillClimbingStatic = false;
        bool stillClimbingMove = false;

        foreach (var overlap in overlaps)
        {
            if (overlap.CompareTag("Climbable Static"))
            {
                stillClimbingStatic = true;
                stillClimbing = true;
            }
            else if (overlap.CompareTag("Climbable Move"))
            {
                stillClimbing = true;
                stillClimbingMove = true;
            }
        }

        isClimbing = stillClimbing;
        isClimbingStatic = stillClimbingStatic;
        isClimbingMove = stillClimbingMove;
        BlinkingPlatforms blinkingPlatform = collision.GetComponent<BlinkingPlatforms>();
        if (blinkingPlatform != null)
            {
                blinkingPlatform.isFalling = false;
            }
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

    // private IEnumerator TimeDelay()
    // {
    //     isBool = true;
    //     objectXID.isBool = true;
    //     isHolding = true;
    //     objectXID.isHolding = true;
    //     Debug.Log("FALLING AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAH");
    //     yield return new WaitForSeconds(1);
    //     isBool = false;
    //     objectXID.isBool = false;
    //     isHolding = false;
    //     objectXID.isHolding = false;
    //     Debug.Log("NO");
    // }
}