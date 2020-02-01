using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // boolean
    public bool disablePlayer = false;
    public Item activeItem {
        get
        {
            return _activeItem;
        }
        set
        {
            _activeItem = value;
            UpdateItemDialog();
        }
    }
    private Item _activeItem = null;

    [Header("Player Stats")]
    public float moveSpeed = 1.0f;

    [Header("Input Manager")]
    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";

    public KeyCode upKeyCode = KeyCode.W;
    public KeyCode downKeyCode = KeyCode.S;
    public KeyCode leftKeyCode = KeyCode.A;
    public KeyCode rightKeyCode = KeyCode.D;

    public KeyCode actionKeyCode = KeyCode.Space;

    [Header("Item Dialog")]
    [SerializeField] private IconBox iconBox = null;

    private string TAG_INTERACTABLE = "Interactable";

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector2 _facingDirection = Vector2.up;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw(horizontalAxis);
        _movement.y = Input.GetAxisRaw(verticalAxis);

        if (Input.GetKeyDown(upKeyCode))
            _facingDirection = Vector2.up;
        else if (Input.GetKeyDown(downKeyCode))
            _facingDirection = Vector2.down;
        else if (Input.GetKeyDown(leftKeyCode))
            _facingDirection = Vector2.left;
        else if (Input.GetKeyDown(rightKeyCode))
            _facingDirection = Vector2.right;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _facingDirection, 10.0f);
        Debug.DrawRay(transform.position, _facingDirection);

        if (hit.collider != null && hit.collider.gameObject.CompareTag(TAG_INTERACTABLE) && Input.GetKeyUp(actionKeyCode))
        {
            var interactObject = hit.collider.gameObject;
            interactObject.GetComponent<Interactable>().Interact(this);
        }
    }

    private void FixedUpdate()
    {
        if (!disablePlayer)
        {
            _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void UpdateItemDialog()
    {
        if (_activeItem != null) iconBox.SetIcon(_activeItem.image);
        else iconBox.SetIcon(null);
    }
}
