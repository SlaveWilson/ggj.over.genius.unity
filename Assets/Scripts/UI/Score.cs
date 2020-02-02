using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static int ordersDelivered = 0;
    public static int ordersFailed = 0;
    public static int totalScore = 0;


    // inspector
    public GameObject _scorePanel;
    public static GameObject scorePanelReference;

    private void Awake()
    {
        scorePanelReference = _scorePanel;
        ordersDelivered = 0;
        ordersFailed = 0;
        totalScore = 0;
    }

    void Update()
    {
        scorePanelReference.transform.Find("Score").GetComponent<TextMeshProUGUI>().text = totalScore.ToString();
    }
}
