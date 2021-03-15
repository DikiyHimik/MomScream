using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private GameObject _emoji;

    private Transform[] _positions;

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

        _tween = transform.DORotate(targetQuaternion.eulerAngles, _timeRotation);
    }

    private void Translate(List<Transform> points)
    {
        Vector3[] traectory = new Vector3[points.Count];

        for (int i = 0; i < traectory.Length; i++)
        {
            traectory[i] = points[i].position;
        }

        _tween = transform.DOPath(traectory, _timeTranslation * _points.Count, PathType.Linear);
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
        _positions = new Transform[transform.childCount];

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] = transform.GetChild(i);
        }
    }
}
