using UnityEngine;

public class Trashcan : Interactable
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public override void Interact(Player player)
    {
        if (player.activeItem == null) return;
        if (player.activeItem.currentState != Item.State.Tool) return;

        player.activeItem = null;
        _anim.SetTrigger("throwStuff");
    }
}
