using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraTranslater : MonoBehaviour
{
    [SerializeField] private GameObject _positionsContainer;
    [SerializeField] private List<CleanerChecker> _checkers;
    [SerializeField] private List<RectTransform> _presenters;
    [SerializeField] private GameObject _endPanel;

    public event UnityAction FrameCnahge;
    public event UnityAction EndingGame;

    private Transform[] _positions;
    private int _numberCurrentPosition;

    private void Start()
    {
        _endPanel.SetActive(false);

        _numberCurrentPosition = 0;

        FillPositionsArray();

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

    private void WaitChangePosition()
    {
        DecreaseScale(_numberCurrentPosition);

        if (_numberCurrentPosition == _positions.Length - 1)
        {
            EndingGame?.Invoke();

            _endPanel.SetActive(true);
        }
        else
        {
            _numberCurrentPosition++;

            IncreaseScale(_numberCurrentPosition);

            FrameCnahge?.Invoke();
        }

        SetCameraInPosition();
    }

    private void FillPositionsArray()
    {
        _positions = new Transform[_positionsContainer.transform.childCount];

        for (int i = 0; i < _positions.Length; i++)
        {
            _positions[i] = _positionsContainer.transform.GetChild(i);
        }
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
