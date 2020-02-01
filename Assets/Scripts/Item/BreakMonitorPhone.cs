using UnityEngine;

public class BreakMonitorPhone : Item
{
    public void Update()
    {
        switch (currentState)
        {
            case State.New:
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
