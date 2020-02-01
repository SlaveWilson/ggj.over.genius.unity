using UnityEngine;

public class BreakMonitorPhone : Interactable
{
    public enum State
    {
        New,
        Backup,
        Monitor,
        Done
    }

    public State currentState;

    public override void Interact(Player player)
    {
        switch (currentState)
        {
            case State.New:
                if(player.activeItem == null) player.activeItem = gameObject;
                break;
            case State.Backup:
                break;
            case State.Monitor:
                break;
            case State.Done:
                break;
        }
        Debug.Log("This is a phone", gameObject);
    }
}
