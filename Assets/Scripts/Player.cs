using UnityEngine;

public enum Direction
{
    North,
    South,
    West,
    East
}

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
    private Animator _animator;

    private Vector2 _movement;
    private Vector2 _facingDirection = Vector2.up;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.x = Input.GetAxisRaw(horizontalAxis);
        _movement.y = Input.GetAxisRaw(verticalAxis);

        if (Input.GetKeyDown(upKeyCode))
        {
            _facingDirection = Vector2.up;
            _animator.SetInteger("direction", (int)Direction.North);
        }
        else if (Input.GetKeyDown(downKeyCode))
        {
            _facingDirection = Vector2.down;
            _animator.SetInteger("direction", (int)Direction.South);
        }
        else if (Input.GetKeyDown(leftKeyCode))
        {
            _facingDirection = Vector2.left;
            _animator.SetInteger("direction", (int)Direction.West);
        }
        else if (Input.GetKeyDown(rightKeyCode))
        {
            _facingDirection = Vector2.right;
            _animator.SetInteger("direction", (int)Direction.East);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _facingDirection, 15.0f);
        Debug.DrawRay(transform.position, _facingDirection * 15.0f, Color.red);

        if (hit.collider != null && hit.collider.gameObject.CompareTag(TAG_INTERACTABLE))
        {
            var interactable = hit.collider.gameObject.GetComponent<Interactable>();
            interactable.OnTouch();
            if (Input.GetKeyUp(actionKeyCode))
                interactable.Interact(this);
            ResetInteractableColor(interactable);
        } else
        {
            ResetInteractableColor();
        }
    }

    private void ResetInteractableColor(Interactable interactable = null)
    {
        var interactables = FindObjectsOfType<Interactable>();
        foreach (var _interactable in interactables)
        {
            if(_interactable != interactable)
            {
                _interactable.OnTouchLeave();
            }
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
        else iconBox.Close();
    }
}
