using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : Interactable
{
    public IconBox iconBox;

    public List<Item.State> availableStates;
    public float processTime = 5.0f;

    public Sprite processImage;
    public Sprite finishImage;

    public Sprite hardwareSprite;
    public Sprite phoneCaseSprite;

    private Item _currentItem = null;
    private float _endTime = 0.0f;

    private bool _isProcessing = false;
    private bool _isFinishProcessing = false;

    public override void Interact(Player player)
    {
        if (_currentItem == null)
        {
            if (player.activeItem == null) return;
            if (!availableStates.Contains(player.activeItem.currentState)) return;

            _currentItem = player.activeItem;
            player.activeItem = null;

            iconBox.SetIcon(GetTargetToolImage(_currentItem.currentState));
        }
        else
        {
            if (_isFinishProcessing)
            {
                if (player.activeItem != null) return;
                if (_endTime > Time.time) return;

                player.activeItem = _currentItem;
                _currentItem = null;

                _isFinishProcessing = false;
                _isProcessing = false;

                iconBox.Close();
            } else
            {
                if (player.activeItem == null) return;
                if (player.activeItem.currentState != Item.State.Tool) return;

                player.activeItem = null;

                _endTime = Time.time + processTime;

                
                StartCoroutine(ChangeIconCoroutine(processImage, true));

                _isProcessing = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_currentItem != null && Time.time > _endTime && _isProcessing)
        {
            _currentItem.NextState();
            StartCoroutine(ChangeIconCoroutine(finishImage, false));
            _isProcessing = false;
        }
    }

    IEnumerator ChangeIconCoroutine(Sprite sprite, bool isProcessing)
    {
        iconBox.Close();
        yield return new WaitForSeconds(1);
        iconBox.isProcessing = isProcessing;
        iconBox.SetIcon(sprite);
        _isFinishProcessing = true;
    }

    private Sprite GetTargetToolImage(Item.State state)
    {
        switch (state)
        {
            case Item.State.Battery:
                return hardwareSprite;
            case Item.State.SSD:
                return hardwareSprite;
            case Item.State.Monitor:
                return phoneCaseSprite;
            default:
                return finishImage;
        }
    }
}
