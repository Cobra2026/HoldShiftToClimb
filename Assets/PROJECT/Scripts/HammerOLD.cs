// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class HammerController2D : MonoBehaviour
// {
//     private Rigidbody2D hammerRigidbody;
//     private Vector2 lastMousePosition;
//     // private bool isDragging = false;
    // [SerializeField] private int mouseID;

    // public StopAtMaxDistance2D stopAtMaxDistance2D;
    // private bool isClimbing = true;

    // public Transform objectX;
    // public float radius = 170f;

    // void Start()
    // {
        // hammerRigidbody = GetComponent<Rigidbody2D>();
    //     stopAtMaxDistance2D = FindObjectOfType<StopAtMaxDistance2D>();
    // }

    // void Update()
    // {
    //     Vector2 direction = (Vector2)transform.position - (Vector2)objectX.position;

    //     float distance = direction.magnitude;

    //     if (distance > radius)
    //     {
    //         Vector2 directionNormalized = direction.normalized;

    //         Vector2 newPosition = (Vector2)objectX.position + directionNormalized * radius;

    //         transform.position = newPosition;
    //     }
    //     else
    //     {
    //         HandleMouseInput();
    //     }

    // CheckForObjectWithTagX();
    // if (isClimbing)
    // {
    //     hammerRigidbody.gravityScale = 0;
    // }
    // else
    // {
    //     hammerRigidbody.gravityScale = 1;
    // }
    // }

// void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Climbable"))
//         {
//             isClimbing = true;
//         }
//     }

//     void OnCollisionStay2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Climbable"))
//         {
//             isClimbing = true;
//         }
//     }

//     void OnCollisionExit2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Climbable"))
//         {
//             isClimbing = false;
//         }
//     }

// void CheckForObjectWithTagX()
// {
//     float radius = 0.1f;

//     Collider2D hit = Physics2D.OverlapCircle(transform.position, radius);

//     if (hit != null && hit.CompareTag("Climbable"))
//     {
//         Debug.Log("Object is on top of an object with tag 'Climbable'");
//     }
// }
    // private void HandleMouseInput()
    // {
        // float currentDistance = stopAtMaxDistance2D.currentDistance + 1;
        // float maxDistance = stopAtMaxDistance2D.maxDistance;
        // float checkRadius = 0.1f;

        // if (Input.GetMouseButtonDown(mouseID))
        // {
            // if (currentDistance <= maxDistance)
            // {
            // Debug.Log("Yes it's working 1");
            // lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // isDragging = true;
            // }
        // }

        // if (Input.GetMouseButton(mouseID))
        // {
            // if (currentDistance <= maxDistance)
            // {
            // Debug.Log("Yes it's working 2");
//             Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//             Vector2 mouseDelta = currentMousePosition - lastMousePosition;

//             hammerRigidbody.MovePosition(hammerRigidbody.position + mouseDelta);

//             lastMousePosition = currentMousePosition;
//         }


//         if (Input.GetMouseButtonUp(mouseID))
//         {
//             Collider2D hit = Physics2D.OverlapCircle(hammerRigidbody.position, checkRadius);
//         }       
//         }
// }
