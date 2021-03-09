using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslater : MonoBehaviour
{
    [SerializeField] private List<GameObject> _positions;

    private int _numberCurrentPosition;

    private void Start()
    {
        _numberCurrentPosition = 0;

        SetCameraInPosition();
    }

    public void RotateRight()
    {
        if (_numberCurrentPosition == _positions.Count - 1)
        {
            _numberCurrentPosition = 0;
        }
        else
        {
            _numberCurrentPosition++;
        }

        SetCameraInPosition();
    }

    public void RotateLeft()
    {
        if (_numberCurrentPosition == 0)
        {
            _numberCurrentPosition = _positions.Count - 1;
        }
        else
        {
            _numberCurrentPosition--;
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
}
