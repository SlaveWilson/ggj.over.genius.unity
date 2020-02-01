using UnityEngine;

public class BreakMonitorComputer : Item
{
    public Sprite fixedMonitorImage;

    public override void NextState()
    {
        switch (currentState)
        {
            case State.Backup:
                currentState = State.Monitor;
                break;
            case State.Monitor:
                currentState = State.Done;
                image = fixedMonitorImage;
                break;
            default:
                break;
        }
    }
}
