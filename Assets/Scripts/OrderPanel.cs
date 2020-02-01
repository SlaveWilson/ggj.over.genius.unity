using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPanel : MonoBehaviour
{
    public int orderType; //Customize
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
            orderTime = 40f;
        }
        else if (orderType == 1)
        {
            orderTime = 35f;
        }
        else if (orderType == 2)
        {
            orderTime = 30f;
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
            OrderManager.RemoveOrderAt(this.transform.GetSiblingIndex());
            Score.ordersFailed++;
            Score.totalScore = Score.totalScore - 10;
        }
    }
}
