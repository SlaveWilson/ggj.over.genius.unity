using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private string TAG_INTERACTABLE = "Interactable";

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 10.0f);
        Debug.DrawRay(transform.position, Vector2.up);

        if (hit.collider != null && hit.collider.gameObject.CompareTag(TAG_INTERACTABLE) && Input.GetKeyUp("space"))
        {
            var interactObject = hit.collider.gameObject;
            interactObject.GetComponent<Interactable>().Interact();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
