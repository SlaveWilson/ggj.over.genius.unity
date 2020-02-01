public class BreakMonitorPhone : Item
{
    public override void NextState()
    {
        switch (currentState)
        {
            case State.Backup:
                currentState = State.Monitor;
                break;
            case State.Monitor:
                currentState = State.Done;
                break;
            default:
                break;
        }
    }
}
