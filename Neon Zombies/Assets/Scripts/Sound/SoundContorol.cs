using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundContorol : MonoBehaviour
{
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soudSlider;
    [SerializeField] AudioMixer _audioMixer;

    [SerializeField] AudioSource hehe;
    [SerializeField] AudioSource anger;
    [SerializeField] AudioSource happy;
    [SerializeField] AudioSource sad;
    [SerializeField] AudioSource run;
    [SerializeField] AudioSource walk;
    [SerializeField] AudioSource eat;

    [SerializeField]
    private PlayerStateController _stateController;

    private void Start()
    {
        if(_musicSlider!=null && _soudSlider != null)
        {
            float music;
            float sound;

            if (_audioMixer.GetFloat("musicVol", out music))
                _musicSlider.value = music;

            if (_audioMixer.GetFloat("musicVol", out sound))
                _musicSlider.value = sound;
        }

        if (_stateController != null) _stateController.EmotionOverloaded += onStateChange;
    }

    private void onStateChange()
    {
        switch (_stateController.PlayerState)
        {
            case Emotions.Fear:
                PlayAngry();
                break;

            case Emotions.Happiness:
                PlayHappy();
                break;

            case Emotions.Sadness:
                PlaySad();
                break;
        }
    }

    public void ChangeMusic()
    {
        _audioMixer.SetFloat("musicVol", _musicSlider.value);
    }

    public void ChangeSound()
    {
        _audioMixer.SetFloat("soundVol", _soudSlider.value);
    }

    public void PlayHappy()
    {
        happy.Play();
    }

    public void PlaySad()
    {
        sad.Play();
    }

    public void PlayAngry()
    {
        anger.Play();
    }

    public void PlayHehe()
    {
        hehe.Play();
    }

    public void PlayEat()
    {
        eat.Play();
    }

    public void PlayRun()
    {
        if(_stateController.PlayerState == Emotions.Fear)
        {
            if (!run.isPlaying) run.Play();
            if (walk.isPlaying) walk.Stop();
        }
        else
        {
            if (run.isPlaying) run.Stop();
            if (!walk.isPlaying) walk.Play();
        }

    }

    public void StopRun()
    {
        run.Stop();
        walk.Stop();
    }
}
