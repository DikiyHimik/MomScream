using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslater : MonoBehaviour
{
    [SerializeField] private List<GameObject> _positions;
    [SerializeField] private List<CleanerChecker> _checkers;
    [SerializeField] private List<RectTransform> _presenters;

    [SerializeField] private AudioSource _audioSourceEndGame;
    [SerializeField] private AudioSource _audioSourceChangeScene;
    [SerializeField] private AudioSource _backGrounMusic;
    [SerializeField] private GameObject _endPanel;

    private int _numberCurrentPosition;

    private void Start()
    {
        _endPanel.SetActive(false);
        _numberCurrentPosition = 0;

        SetCameraInPosition();

        IncreaseScale(_numberCurrentPosition);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _checkers.Count; i++)
        {
            _checkers[i].ZoneCleared += ChangePosition;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _checkers.Count; i++)
        {
            _checkers[i].ZoneCleared -= ChangePosition;
        }
    }

    public void ChangePosition()
    {
        Invoke("WaitChangePosition", 3);
    }

    public void PlayMusic()
    {
        _backGrounMusic.Play();
    }

    private void WaitChangePosition()
    {
        DecreaseScale(_numberCurrentPosition);

        if (_numberCurrentPosition == _positions.Count - 1)
        {
            _backGrounMusic.Stop();
            _audioSourceEndGame.Play();
            _endPanel.SetActive(true);
        }
        else
        {
            _numberCurrentPosition++;

            IncreaseScale(_numberCurrentPosition);

            _audioSourceChangeScene.Play();
        }

        SetCameraInPosition();
    }

    private void SetCameraInPosition()
    {
        Vector3 newPosition = _positions[_numberCurrentPosition].transform.position;
        Quaternion newQuaternion = _positions[_numberCurrentPosition].transform.rotation;

        gameObject.transform.position = newPosition;
        gameObject.transform.rotation = newQuaternion;
    }

    private void IncreaseScale(int index)
    {
        Vector3 newScale = new Vector3(_presenters[index].localScale.x, _presenters[index].localScale.y, _presenters[index].localScale.z) * 1.3f;

        _presenters[index].localScale = newScale;
    }

    private void DecreaseScale(int index)
    {
        Vector3 newScale = new Vector3(_presenters[index].localScale.x, _presenters[index].localScale.y, _presenters[index].localScale.z) / 1.3f;

        _presenters[index].localScale = newScale;
    }
}
