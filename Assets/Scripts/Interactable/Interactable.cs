using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;

    private SpriteRenderer sprite;
    //private Color colorOnTouch = new Color();

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
        sprite.color = Color.gray;
    }

    public virtual void OnTouchLeave()
    {
        sprite.color = Color.white;
    }
}
