using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float durationInSecond = 90f;
    public static bool isStart = false;
    public static bool isStop = true;

    public static float remainingTime {
        get
        {
            return _remainingTime;
        }
        set
        {
            _remainingTime = value;
            UpdateTimeUI();
        }
    }

    private static float _remainingTime;
    private static float _endTime = 0.0f;
    private static TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpdateTimeUI();
    }

    private void FixedUpdate()
    {
        if (!isStop)
        {
            remainingTime = _endTime - Time.time;
            if (remainingTime <= 1)
            {
                isStop = true;
            }
        }
    }

    private static void UpdateTimeUI()
    {
        _text.text = remainingTime.CovertToTimeFormatString();
    }

    [ContextMenu("Start Timer")]
    public static void StartTimer()
    {
        isStart = true;
        isStop = false;
        _endTime = Time.time + durationInSecond + 1.0f;
    }

    [ContextMenu("Stop Timer")]
    public static void StopTimer()
    {
        isStop = true;
        remainingTime = 0.0f;
    }
}
