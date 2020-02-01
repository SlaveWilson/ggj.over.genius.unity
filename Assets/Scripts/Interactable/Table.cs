using UnityEngine;

public class Table : Interactable
{
    public SpriteRenderer itemImage;

    public Item item = null;

    private void Start()
    {
        itemImage.sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 1;
        if (item != null)
            itemImage.sprite = item.image;
    }

    public override void Interact(Player player)
    {
        if (item == null)
        {
            PutDown(player);
        } else
        {
            Pickup(player);
        }
    }

    private void Pickup(Player player)
    {
        player.activeItem = item;
        item = null;
        itemImage.sprite = null;
    }

    private void PutDown(Player player)
    {
        if (player.activeItem == null) return;
        item = player.activeItem;
        player.activeItem = null;
        itemImage.sprite = item.image;
    }
}
