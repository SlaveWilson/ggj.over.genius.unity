using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    public int orderType; //Customize
    public int orderCount = 0;
    public float orderTime;
    public Slider slider;

    // Start is called before the first frame update
    private void Awake()
    {
        slider = this.transform.Find("Slider").GetComponent<Slider>();
    }
    void Start()
    {
        Debug.Log(orderType);
        slider.value = 1f;
        if (orderType == 0)
        {
            orderTime = 50f;
        }
        else if (orderType == 1)
        {
            orderTime = 40f;
        }
        else if (orderType == 2)
        {
            orderTime = 50f;
        }
    }
    private void FixedUpdate()
    {
        if (slider.value > 0)
        {
            slider.value -= Time.fixedDeltaTime/orderTime;
        }
        else
        {
            OrderManager.RemoveOrder(gameObject);
            Score.ordersFailed++;
            Score.totalScore = Score.totalScore - 10;
        }
    }
}
