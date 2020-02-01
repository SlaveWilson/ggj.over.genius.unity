using UnityEngine;

public class BackupTable : Interactable
{
    public CountDownBar countTimeBar;

    public override void Interact(Player player)
    {
        if (player.activeItem == null) return;
    }
}
