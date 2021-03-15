using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private GameObject _emoji;

    private Vector3[] _positions;
    private Vector3 _endRotation;

    private Camera _mainCamera;
    private float _timeRotation = 1;
    private float _timeTranslation = 1;

    private Tween _tween;

    private void Start()
    {
        _mainCamera = Camera.main;

        FillArrayPositions();
    }

    public void Move()
    {
        Translate(_points);

        Rotate(_points[_points.Count - 1]);

        Invoke("PlayParticleSystem", _timeTranslation * _points.Count);
    }

    private void Rotate(Transform endPoint)
    {
        Quaternion targetQuaternion = endPoint.rotation;

        _tween = transform.DORotate(_endRotation, _timeRotation);
    }

    private void Translate(List<Transform> points)
    {
        Vector3[] traectory = new Vector3[points.Count];

        for (int i = 0; i < traectory.Length; i++)
        {
            traectory[i] = points[i].position;
        }

        _tween = transform.DOPath(_positions, _timeTranslation * _points.Count, PathType.Linear);
    }

    private void PlayParticleSystem()
    {
        GameObject _emojiSysytem = Instantiate(_emoji, gameObject.transform.position, Quaternion.identity);
        _emojiSysytem.transform.LookAt(_mainCamera.transform.position);
        _emojiSysytem.transform.Translate(Vector3.forward);
        _emojiSysytem.GetComponent<ParticleSystem>().Play();
    }

    private void FillArrayPositions()
    {
        _positions = new Vector3[transform.childCount];

        for (int i = 0; i < _positions.Length; i++)
        {
            Transform newPosition = transform.GetChild(i);

            _positions[i] = newPosition.position;

            _endRotation = newPosition.rotation.eulerAngles;
        }
    }
}