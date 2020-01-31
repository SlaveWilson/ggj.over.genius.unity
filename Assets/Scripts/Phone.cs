using UnityEngine;

public class Phone : Interactable
{
    public override void Interact()
    {
        Debug.Log("This is a phone", gameObject);
    }
}
