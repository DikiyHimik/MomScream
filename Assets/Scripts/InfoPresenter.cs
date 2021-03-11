using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoPresenter : MonoBehaviour
{
    [SerializeField] private Text _text;

    private Slider _slider;
    private int _commonCountItems;
    private int _clearedItems;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangeScene(int count)
    {
        _commonCountItems = count;

        _slider.maxValue = count;
        _slider.value = 0;

        _clearedItems = 0;

        WriteInfo();
    }

    public void ChangeCountClearedItems()
    {
        _slider.value++;

        _clearedItems++;

        WriteInfo();
    }

    private void WriteInfo()
    {
        _text.text = $"{_clearedItems}/{_commonCountItems}";
    }
}
