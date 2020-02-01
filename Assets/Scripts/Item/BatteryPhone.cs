public class BatteryPhone : Item
{
    public override void NextState()
    {
        switch (currentState)
        {
            case State.Backup:
                currentState = State.Battery;
                break;
            case State.Battery:
                currentState = State.Done;
                break;
            default:
                break;
        }
    }
}
