using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private string TAG_INTERACTABLE = "Interactable";

    private Interactable _activeItem = null;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _facingDirection = Vector2.up;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
            _facingDirection = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S))
            _facingDirection = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.A))
            _facingDirection = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.D))
            _facingDirection = Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _facingDirection, 10.0f);
        Debug.DrawRay(transform.position, _facingDirection);

        if (hit.collider != null && hit.collider.gameObject.CompareTag(TAG_INTERACTABLE) && Input.GetKeyUp("space"))
        {
            var interactObject = hit.collider.gameObject;
            interactObject.GetComponent<Interactable>().Interact();
        }
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
    }
}
