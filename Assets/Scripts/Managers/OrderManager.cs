using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // reference

    // Inspector elements
    public GameObject _canvas;
    public static GameObject canvasReference;


    public List<GameObject> _allOrderPanel;
    public static List<GameObject> allOrderPanelReference;



    public static List<GameObject> allOrders = new List<GameObject>();
    

    private void Awake()
    {
        canvasReference = _canvas;
        allOrderPanelReference = _allOrderPanel;
    }

    public static void StartOrder()
    {
        AddOrder(0);
        AddOrder(1);
        AddOrder(2);
    }

    private static void AddOrder(int type)
    {
        GameObject order = Instantiate(allOrderPanelReference[type], canvasReference.transform);
        allOrders.Add(order);
    }
    public static void RemoveOrderAt(int i)
    {
        allOrders.RemoveAt(i);
        Destroy(canvasReference.transform.GetChild(i).gameObject);
    }
    public static void CheckOrder(int type)
    {
        int i = 0;
        foreach (GameObject order in allOrders)
        {
            if (order.GetComponent<OrderPanel>().orderType == type)
            {
                RemoveOrderAt(i);
                Debug.Log("Correct repair! (type " + type + ")");
                SoundManager.CorrectRepairSE(type);
                return;
            }
            i++;
        }
        Debug.Log("Wrong repair!");
        SoundManager.WrongRepairSE();
    }
}