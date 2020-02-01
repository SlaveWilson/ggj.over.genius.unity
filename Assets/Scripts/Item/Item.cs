using UnityEngine;

public class Item : MonoBehaviour
{
    public enum State
    {
        New,
        Tool,
        Backup,
        Monitor,
        Battery,
        SSD,
        Strap,
        Done
    }

    public State currentState;
    public Client client;

    public Sprite image;

    public virtual void NextState()
    {
        currentState = State.Done;
    }
}
