using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float durationInSecond = 90.0f;
    public bool isStop = true;

    public float remainingTime {
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

    private float _remainingTime;
    private float _endTime = 0.0f;
    private TextMeshProUGUI _text;

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
            if (remainingTime < 0)
            {
                isStop = true;
            }
        }
    }

    private void UpdateTimeUI()
    {
        _text.text = remainingTime.CovertToTimeFormatString();
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
        isStop = true;
        remainingTime = 0.0f;
    }
}
