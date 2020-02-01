using System.Collections;
using UnityEngine;

public class Machine : Interactable
{
    public IconBox iconBox;

    public Item.State availableState = Item.State.Backup;
    public float processTime = 5.0f;

    public Sprite processImage;
    public Sprite finishImage;

    private Item _currentItem = null;
    private float _endTime = 0.0f;

    private bool _isProcessing = false;
    private bool _isFinishProcessing = false;

    public override void Interact(Player player)
    {
        if (_currentItem == null)
        {
            if (player.activeItem == null) return;
            if (player.activeItem.currentState != availableState) return;

            _currentItem = player.activeItem;
            player.activeItem = null;
            _endTime = Time.time + processTime;

            iconBox.SetIcon(processImage);

            _isProcessing = true;
        } else
        {
            if (player.activeItem != null) return;
            if (_endTime > Time.time) return;
            if (!_isFinishProcessing) return;

            player.activeItem = _currentItem;
            _currentItem = null;

            iconBox.Close();
        }
    }

    private void FixedUpdate()
    {
        if(_currentItem != null && Time.time > _endTime && _isProcessing)
        {
            _currentItem.NextState();
            StartCoroutine(ChangeIconCoroutine(finishImage));
            _isProcessing = false;
        }
    }

    IEnumerator ChangeIconCoroutine(Sprite sprite)
    {
        iconBox.Close();
        yield return new WaitForSeconds(1);
        iconBox.SetIcon(sprite);
        _isFinishProcessing = true;
    }
}
