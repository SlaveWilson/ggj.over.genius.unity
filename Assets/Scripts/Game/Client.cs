using UnityEngine;

public class Client : Interactable
{
    public int orderType;
    public int orderCount; //start from 0

    public override void Interact(Player player)
    {
        Debug.Log("Interact with client");
    }
}
