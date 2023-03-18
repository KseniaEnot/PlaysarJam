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
    }

    public void ChangeMusic()
    {
        _audioMixer.SetFloat("musicVol", _musicSlider.value);
    }

    public void ChangeSound()
    {
        _audioMixer.SetFloat("soundVol", _soudSlider.value);
    }
}
