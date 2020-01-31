using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private string TAG_INTERACTABLE = "Interactable";

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 facingDirection = Vector2.up;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
            facingDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S))
            facingDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A))
            facingDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D))
            facingDirection = Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, 10.0f);
        Debug.DrawRay(transform.position, facingDirection);

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
