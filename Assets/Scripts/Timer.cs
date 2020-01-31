using UnityEngine;

public class Timer : MonoBehaviour
{
    public float durationInSecond = 90.0f;
    public bool isStop = true;

    public float remainingTime;

    private float _endTime = 0.0f;

    private void FixedUpdate()
    {
        if (!isStop)
        {
            remainingTime = _endTime - Time.time;
            if(remainingTime < 0)
            {
                isStop = true;
            }
        }
    }

    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        isStop = false;
        _endTime = Time.time + durationInSecond;
    }

    [ContextMenu("Stop Timer")]
    public void StopTimer()
    {

    }
}
