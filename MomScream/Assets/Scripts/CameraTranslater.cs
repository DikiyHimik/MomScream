using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslater : MonoBehaviour
{
    [SerializeField] private List<GameObject> _positions;
    [SerializeField] private List<CleanerChecker> _checkers;

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

        _checkers[_numberCurrentPosition].ChangePosition();
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
        if (_numberCurrentPosition == _positions.Count - 1)
        {
            _backGrounMusic.Stop();
            _audioSourceEndGame.Play();
            _endPanel.SetActive(true);
        }
        else
        {
            _numberCurrentPosition++;

            _checkers[_numberCurrentPosition].ChangePosition();
            _audioSourceChangeScene.Play();
        }

        SetCameraInPosition();
    }

    public void PlayMusic()
    {
        _backGrounMusic.Play();
    }

    private void SetCameraInPosition()
    {
        Vector3 newPosition = _positions[_numberCurrentPosition].transform.position;
        Quaternion newQuaternion = _positions[_numberCurrentPosition].transform.rotation;

        gameObject.transform.position = newPosition;
        gameObject.transform.rotation = newQuaternion;
    }
}
