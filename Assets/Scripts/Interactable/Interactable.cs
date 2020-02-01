using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public virtual void Interact(Player player)
    {
        Debug.Log("No Interact Action", gameObject);
    }

    public virtual void OnTouch()
    {
        sprite.color = new Color(215.0f/ 255.0f, 215.0f / 255.0f, 215.0f / 255.0f);
    }

    public virtual void OnTouchLeave()
    {
        sprite.color = Color.white;
    }
}
