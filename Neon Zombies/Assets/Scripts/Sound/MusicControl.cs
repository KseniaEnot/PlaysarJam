using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    [SerializeField]
    private AudioSource _happyMusic;
    [SerializeField]
    private AudioSource _sadMusic;
    [SerializeField]
    private AudioSource _angryMusic;

    [SerializeField]
    private PlayerStateController _stateController;

    private void Start()
    {
        if(_stateController != null) _stateController.StateChanged += onStateChange;
    }

    private void onStateChange(Emotions state)
    {
        _happyMusic.Stop();
        _angryMusic.Stop();
        _sadMusic.Stop();
        switch (state)
        {
            case Emotions.Fear:
                _angryMusic.Play();
                break;
            case Emotions.Happiness:
                _happyMusic.Play();
                break;
            case Emotions.Sadness:
                _sadMusic.Play();
                break;
        }
    }

}
