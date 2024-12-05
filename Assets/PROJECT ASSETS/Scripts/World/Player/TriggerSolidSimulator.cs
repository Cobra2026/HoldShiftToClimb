using UnityEngine;

public class TriggerSolidSimulator : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        if (col == null || rb == null)
        {
            Debug.LogError("This object needs both a Rigidbody2D and a Collider2D!");
        }

        col.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collider2D playerCollider = other.GetComponent<Collider2D>();
            if (playerCollider != null)
            {
                playerCollider.isTrigger = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collider2D playerCollider = other.GetComponent<Collider2D>();
            if (playerCollider != null)
            {
                playerCollider.isTrigger = true;
            }
        }
    }
}
