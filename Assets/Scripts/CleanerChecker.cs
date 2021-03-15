using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanerChecker : MonoBehaviour
{
    [SerializeField] private InfoPresenter _infoPresenter;
    [SerializeField] private AudioSource _audioSourceItemClicked;

    private TouchDetector[] _detectors;

    private int _countItemsInZone;
    private int _countClearedItems;

    public event UnityAction ZoneCleared;

    private void Awake()
    {
        _countClearedItems = 0;

        _countItemsInZone = _detectors.Length;

        FillArrayDetectors();
    }

    private void OnDisable()
    {
        for (int i = 0; i < _detectors.Length; i++)
        {
            _detectors[i].ItemWasRemoved -= CheckClearedZone;
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < _detectors.Length; i++)
        {
            _detectors[i].ItemWasRemoved += CheckClearedZone;
        }
    }

    private void FillArrayDetectors()
    {
        _detectors = new TouchDetector[transform.childCount];

        for (int i = 0; i < _detectors.Length; i++)
        {
            _detectors[i] = transform.GetComponentInChildren<TouchDetector>();
        }
    }

    private void CheckClearedZone()
    {
        _audioSourceItemClicked.Play();

        Invoke("AddClearedItems", 1);
    }

    private void AddClearedItems()
    {
        _countClearedItems++;

        _infoPresenter.AddValue();

        if (_countClearedItems == _countItemsInZone)
        {
            ZoneCleared?.Invoke();
        }
    }


}
