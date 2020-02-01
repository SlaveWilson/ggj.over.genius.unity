using UnityEngine;

public class Table : Interactable
{
    public SpriteRenderer itemImage;

    public Item item = null;

    private void Start()
    {
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
        item = player.activeItem;
        player.activeItem = null;
        itemImage.sprite = item.image;
    }
}
