using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGamePanel : MonoBehaviour
{
    public GameObject ordersDelivered;
    public GameObject ordersFailed;
    public GameObject totalScore;
    public GameObject playAgain;
    public GameObject exit;

    // boolean
    public static bool canPlayAgain = false;
    public static bool canExit = false;

    private void Awake()
    {
        ordersDelivered = this.transform.Find("OrdersDelivered").gameObject;
        ordersFailed = this.transform.Find("OrdersFailed").gameObject;
        totalScore = this.transform.Find("TotalScore").gameObject;
        playAgain = this.transform.Find("PlayAgain").gameObject;
        exit = this.transform.Find("Exit").gameObject;
    }

    void Start()
    {
        ordersDelivered.GetComponent<TextMeshProUGUI>().text = Score.ordersDelivered.ToString() + " x 20 = " 
        + (Score.ordersDelivered * 20).ToString();
        ordersFailed.GetComponent<TextMeshProUGUI>().text = Score.ordersFailed.ToString() + " x 10 = "
        + (Score.ordersFailed * 10).ToString();
        totalScore.GetComponent<TextMeshProUGUI>().text = Score.totalScore.ToString();

        playAgain.GetComponent<Button>().onClick.AddListener(
        () => canPlayAgain = true);

        exit.GetComponent<Button>().onClick.AddListener(
        () => canExit = true);
    }


}
