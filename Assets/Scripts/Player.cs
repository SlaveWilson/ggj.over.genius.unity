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

        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y) + 10;

        _facingDirection = _movement.normalized == Vector2.zero ? _facingDirection : _movement.normalized;

        if (_facingDirection == Vector2.up || _facingDirection == new Vector2(0.7f, 0.7f).normalized)
        {
            _facingDirection = Vector2.up;
            _animator.SetInteger("direction", (int)Direction.North);
        }
        else if (_facingDirection == Vector2.down || _facingDirection == new Vector2(-0.7f, -0.7f).normalized)
        {
            _facingDirection = Vector2.down;
            _animator.SetInteger("direction", (int)Direction.South);
        }
        else if (_facingDirection == Vector2.left || _facingDirection == new Vector2(-0.7f, 0.7f).normalized)
        {
            _facingDirection = Vector2.left;
            _animator.SetInteger("direction", (int)Direction.West);
        } else
        {
            _facingDirection = Vector2.right;
            _animator.SetInteger("direction", (int)Direction.East);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, _facingDirection, 10.0f);
        Debug.DrawRay(transform.position, _facingDirection * 10.0f, Color.red);

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
        if (_activeItem != null)
        {
            if (_activeItem.currentState == Item.State.Done) iconBox.showTickIcon = true;
            iconBox.SetIcon(_activeItem.image);
        }
        else iconBox.Close();
    }
}
