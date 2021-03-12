using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CleanerChecker : MonoBehaviour
{
    [SerializeField] private List<TouchDetector> _detectors;
    [SerializeField] private InfoPresenter _infoPresenter;
    [SerializeField] private AudioSource _audioSourceItemClicked;

    private int _countItemsInZone;
    private int _countClearedItems;

    public event UnityAction ZoneCleared;

    private void Awake()
    {
        _countClearedItems = 0;

        _countItemsInZone = _detectors.Count;
    }

    private void OnDisable()
    {
        for (int i = 0; i < _detectors.Count; i++)
        {
            _detectors[i].ItemWasRemoved -= CheckClearedZone;
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < _detectors.Count; i++)
        {
            _detectors[i].ItemWasRemoved += CheckClearedZone;
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
        _infoPresenter.ChangeCountClearedItems();

        if (_countClearedItems == _countItemsInZone)
        {
            ZoneCleared?.Invoke();
        }
    }
}
