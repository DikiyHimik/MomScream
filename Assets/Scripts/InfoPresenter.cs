using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoPresenter : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _fill;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _fill.SetActive(false);

        _slider.maxValue = 34;
    }

    public void ChangeCountClearedItems()
    {
        _fill.SetActive(true);

        _slider.value++;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
