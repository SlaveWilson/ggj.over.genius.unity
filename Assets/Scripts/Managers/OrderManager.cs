using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    // reference
    public static OrderManager instance;

    // Inspector elements
    public GameObject _canvas;
    public static GameObject canvasReference;


    public List<GameObject> _allOrderPanel;
    public static List<GameObject> allOrderPanelReference;


    // Generate items in scene
    public List<GameObject> _possibleTable;
    public static List<GameObject> possibleTableReference;
    public List<GameObject> _possibleItem;
    public static List<GameObject> possibleItemReference;
    public Table table;
    public Item item;


    public static int orderCount = 0;


    public static List<GameObject> allOrders = new List<GameObject>();
    

    private void Awake()
    {
        instance = this;
        canvasReference = _canvas;
        allOrderPanelReference = _allOrderPanel;


        possibleTableReference = _possibleTable;
        possibleItemReference = _possibleItem;


        orderCount = 0;
    }

    public static void StartOrder()
    {
        instance.StartCoroutine(instance.StartOrderIE());
    }

    IEnumerator StartOrderIE()
    {
        float t = Random.Range(2f, 5f);
        yield return new WaitForSeconds(t);
        int o = Random.Range(0, 3);
        instance.AddOrder(o);
        t = Random.Range(20f, 25f);
        yield return new WaitForSeconds(t);
        o = Random.Range(0, 3);
        instance.AddOrder(o);
        t = Random.Range(20f, 25f);
        yield return new WaitForSeconds(t);
        int n = Random.Range(1, 3);
        for (int i = 0; i < n; i++)
        {
            o = Random.Range(0, 3);
            instance.AddOrder(o);
        }
        if (n == 1)
        {
            t = Random.Range(2f, 5f);
            yield return new WaitForSeconds(t);
            o = Random.Range(0, 3);
            instance.AddOrder(o);
        }
        t = Random.Range(20f, 25f);
        yield return new WaitForSeconds(t);
        for (int i = 0; i < 3; i++)
        {
            o = Random.Range(0, 3);
            instance.AddOrder(o);
        }
    }

    private void AddOrder(int orderType)
    {
        GameObject order = Instantiate(allOrderPanelReference[orderType], canvasReference.transform);
        order.GetComponent<OrderPanel>().orderCount = orderCount;
        allOrders.Add(order);

        // Generate in scene
        int r = Random.Range(0, possibleTableReference.Count);
        while (possibleTableReference[r].GetComponent<Table>().item != null)
        {
            r = Random.Range(0, possibleTableReference.Count);
        }
        possibleTableReference[r].GetComponent<Table>().item = Instantiate(possibleItemReference[orderType]).GetComponent<Item>();

        possibleTableReference[r].GetComponent<Table>().itemImage.sortingOrder = possibleTableReference[r].GetComponent<Table>().GetComponent<SpriteRenderer>().sortingOrder + 1;
        possibleTableReference[r].GetComponent<Table>().itemImage.sprite = possibleTableReference[r].GetComponent<Table>().item.image;

        // Add item information
        possibleTableReference[r].GetComponent<Table>().item.client = new Client();
        possibleTableReference[r].GetComponent<Table>().item.client.orderType = orderType;
        possibleTableReference[r].GetComponent<Table>().item.client.orderCount = orderCount;
        orderCount++;
    }
    public static void RemoveOrder(GameObject orderPanel)
    {
        allOrders.Remove(orderPanel);
        Destroy(orderPanel);
    }
    public static void RemoveFinishedOrder(int orderCount)
    {
        foreach (GameObject order in allOrders)
        {
            Debug.Log(order);
            if (order.GetComponent<OrderPanel>().orderCount == orderCount)
            {
                RemoveOrder(order);
                Score.ordersDelivered++;
                Score.totalScore = Score.totalScore + 20;
                return;
            }
        }
        Debug.Log("Wrong repair!");
        SoundManager.WrongRepairSE();
    }
}