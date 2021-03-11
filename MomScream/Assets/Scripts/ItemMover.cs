using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMover : MonoBehaviour
{
    float _timeRotation = 1;
    float _timeTranslation = 1;
    private Transform _endPosition;

    private Tween _tween;

    private void Start()
    {
        Transform child = transform.GetChild(0);

        _endPosition = child.transform;
    }

    public void Move()
    {
        Rotate();
        Translate();
    }

    private void Rotate()
    {
        Quaternion targetQuaternion = _endPosition.rotation;

        _tween = transform.DORotate(targetQuaternion.eulerAngles, _timeRotation);
    }

    private void Translate()
    {
        Vector3 targetPosition = _endPosition.position;

        _tween = transform.DOMove(targetPosition, _timeTranslation);
    }

    private void SetPosition()
    {
        Vector3 newPosition = _endPosition.position;
        Quaternion newQuaternion = _endPosition.rotation;

        gameObject.transform.position = newPosition;
        gameObject.transform.rotation = newQuaternion;
    }
}
