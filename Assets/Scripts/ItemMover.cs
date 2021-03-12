using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private GameObject _emoji;

    private Camera _mainCamera;
    private float _timeRotation = 1;
    private float _timeTranslation = 1;

    private Tween _tween;

    private void Start()
    {
        _mainCamera = Camera.main;
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

    private void SetParticleSystem(ParticleSystem particles)
    {
        Vector3 position = transform.position;

        particles.transform.position = position;
        particles.transform.LookAt(_mainCamera.transform.position);
    }
}
