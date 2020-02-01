public class TransferDataComputer : Item
{
    public override void NextState()
    {
        switch (currentState)
        {
            case State.Backup:
                currentState = State.Done;
                break;
            default:
                break;
        }
    }
}
