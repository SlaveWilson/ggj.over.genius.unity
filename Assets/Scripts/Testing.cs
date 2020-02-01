using UnityEngine;

public class Testing : MonoBehaviour
{
    public Table table;
    public Item item;

    private void Awake()
    {
        table.item = Instantiate(item).GetComponent<Item>();
    }
}
