using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private CameraTranslater _cameraTranslater;
    [SerializeField] private AudioManager _audioManager;

    private void OnEnable()
    {
        _cameraTranslater.FrameCnahge += ModificateFrame;
        _cameraTranslater.EndingGame += EndGame;
    }

    private void OnDisable()
    {
        _cameraTranslater.FrameCnahge -= ModificateFrame;
        _cameraTranslater.EndingGame += EndGame;
    }

    public void StartGame()
    {
        _audioManager.PlayFoneMusic();
    }

    private void ModificateFrame()
    {
        _audioManager.PlayChangerSceneMusic();
    }

    private void EndGame()
    {
        _audioManager.PlayEndGameMusic();
    }
}
