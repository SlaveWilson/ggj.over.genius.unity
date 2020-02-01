using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool isInteractable = true;

    public virtual void Interact(Player player)
    {
        Debug.Log("No Interact Action", gameObject);
    }
}
