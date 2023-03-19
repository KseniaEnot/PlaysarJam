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

    [SerializeField] float transitionTime = 1f;
    Vector3 initialScale;

    IEnumerator ChangeMusic(AudioSource start, AudioSource stop)
    {
        start.Play();
        start.volume = 0f;
        stop.volume = 1f;
        float step = 0.01f;
        float iterations = transitionTime / step;
        for (float i = 0; i < iterations; i++)
        {
            float a = i / iterations;
            Debug.Log(a);
            start.volume = Mathf.Clamp(a,0f,1f);
            stop.volume = Mathf.Clamp(1 - a, 0f, 1f);
            yield return new WaitForSeconds(step*3);
        }
        stop.Stop();
    }

    private void Start()
    {
        if(_stateController != null) _stateController.StateChanged += onStateChange;
    }

    private void onStateChange(Emotions state)
    {
        switch (state)
        {
            case Emotions.Fear:
                if (_happyMusic.isPlaying) StartCoroutine(ChangeMusic(_angryMusic, _happyMusic));
                if (_sadMusic.isPlaying) StartCoroutine(ChangeMusic(_angryMusic, _sadMusic));
                break;
            case Emotions.Happiness:
                if (_angryMusic.isPlaying) StartCoroutine(ChangeMusic(_happyMusic, _angryMusic));
                if (_sadMusic.isPlaying) StartCoroutine(ChangeMusic(_happyMusic, _sadMusic));
                break;
            case Emotions.Sadness:
                if (_angryMusic.isPlaying) StartCoroutine(ChangeMusic(_sadMusic, _angryMusic));
                if (_happyMusic.isPlaying) StartCoroutine(ChangeMusic(_sadMusic, _happyMusic));
                break;
        }
    }

}
