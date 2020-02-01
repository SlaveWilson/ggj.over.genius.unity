using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // reference

    // Inspector elements
    public GameObject _canvas;
    public static GameObject canvasReference;

    public GameObject _orderPanel;
    public static GameObject orderPanelReference;


    public static List<GameObject> allOrders = new List<GameObject>();
    

    private void Awake()
    {
        canvasReference = _canvas;
        orderPanelReference = _orderPanel;
    }
    public static void StartOrder()
    {

    }

    private static void AddOrder()
    {
        GameObject order = Instantiate(orderPanelReference, canvasReference.transform);
        allOrders.Add(order);
    }
    public static void RemoveOrder(int i)
    {
        allOrders.RemoveAt(i);
    }
    public static void CheckOrder(int i)
    {
        int j = 0;
        foreach (GameObject order in allOrders)
        {
            if (order.GetComponent<OrderPanel>().orderType == i)
            {
                RemoveOrder(j);
                Debug.Log("Correct repair! (type " + i + ")");
                SoundManager.CorrectRepairSE(i);
                return;
            }
            j++;
        }
        Debug.Log("Wrong repair!");
        SoundManager.WrongRepairSE();
    }
}