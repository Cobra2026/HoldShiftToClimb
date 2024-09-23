using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController2D : MonoBehaviour
{
    private Rigidbody2D hammerRigidbody;   // The hammer's Rigidbody2D component
    private Vector2 lastMousePosition;     // Store the last mouse position
    private bool isDragging = false;       // Is the mouse button being held
    [SerializeField] private int mouseID;

    public StopAtMaxDistance2D stopAtMaxDistance2D;

    void Start()
    {
        hammerRigidbody = GetComponent<Rigidbody2D>();
        stopAtMaxDistance2D = FindObjectOfType<StopAtMaxDistance2D>();
    }

    void Update()
    {
        HandleMouseInput();
    }

    private void HandleMouseInput()
    {
        float currentDistance = stopAtMaxDistance2D.currentDistance + 1;
        float maxDistance = stopAtMaxDistance2D.maxDistance;

        if (Input.GetMouseButtonDown(mouseID))
        {
            // Initialize the last mouse position when the dragging starts
            if (currentDistance <= maxDistance)
            {
                Debug.Log("Yes it's working 1");
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
            }
        }

        if (Input.GetMouseButton(mouseID) && isDragging)
        {
            if (currentDistance <= maxDistance)
            {
                Debug.Log("Yes it's working 2");
            // Get the current mouse position in world space
            Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Calculate the difference between the current and last mouse position
            Vector2 mouseDelta = currentMousePosition - lastMousePosition;

            // Move the hammer by the same delta
            hammerRigidbody.MovePosition(hammerRigidbody.position + mouseDelta);

            // Update last mouse position to the current one for the next frame
            lastMousePosition = currentMousePosition;
            }
        }

        if (Input.GetMouseButtonUp(mouseID) || currentDistance >= maxDistance)
        {
            isDragging = false;
        }
    }
}
