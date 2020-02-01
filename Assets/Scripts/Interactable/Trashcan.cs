public class Trashcan : Interactable
{
    public override void Interact(Player player)
    {
        if (player.activeItem == null) return;
        if (player.activeItem.currentState != Item.State.Tool) return;

        player.activeItem = null;
    }
}
