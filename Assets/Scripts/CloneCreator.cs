using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneCreator : MonoBehaviour
{
    private GameObject _clone;
    private Transform _position;

    private void Start()
    {
        _position = transform.GetChild(0);

        InstantiateCLone();
    }

    private void InstantiateCLone()
    {
        //_clone = Instantiate(gameObject, _position);
        Debug.Log("создание предмета");
    }

    public void DestroyClone()
    {
        Destroy(_clone);
    }
}
