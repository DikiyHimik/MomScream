using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ItemMover))]
[RequireComponent(typeof(BoxCollider))]

public class TouchDetector : MonoBehaviour
{
    private ItemMover _itemMover;

    private bool _isRemoved;

    public event UnityAction ItemWasRemoved;

    private void Start()
    {
        _itemMover = GetComponent<ItemMover>();
        _isRemoved = false;
    }

    public void OnMouseUp()
    {
        if (_isRemoved == false)
        {
            _itemMover.Move();

            _isRemoved = true;

            ItemWasRemoved?.Invoke();
        }
    }
}
