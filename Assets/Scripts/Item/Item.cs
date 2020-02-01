using UnityEngine;

public class Item : MonoBehaviour
{
    public enum State
    {
        Tool,
        Backup,
        Monitor,
        Battery,
        SSD,
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
