using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPresenter : MonoBehaviour
{
    private TMP_Text _text;
    private int _commonCountItems;
    private int _clearedItems;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void ChangeScene(int count)
    {
        _commonCountItems = count;
        _clearedItems = 0;

        WriteInfo();
    }

    public void ChangeCountClearedItems()
    {
        _clearedItems++;

        WriteInfo();
    }

    private void WriteInfo()
    {
        _text.text = $"Убрано предметов {_clearedItems}/{_commonCountItems}";
    }
}
