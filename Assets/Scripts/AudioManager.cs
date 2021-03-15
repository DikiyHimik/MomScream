using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _endGameMusic;
    [SerializeField] private AudioSource _changerSceneMusic;
    [SerializeField] private AudioSource _foneMusic;
    
    public void PlayEndGameMusic()
    {
        _foneMusic.Stop();

        _endGameMusic.Play();
    }

    public void PlayFoneMusic()
    {
        _foneMusic.Play();
    }

    public void PlayChangerSceneMusic()
    {
        _changerSceneMusic.Play();
    }
}
