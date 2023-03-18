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
    private AudioSource hehe;

    public void ChangeMusic()
    {
        _audioMixer.SetFloat("musicVol", _musicSlider.value);
    }

    public void ChangeSound()
    {
        _audioMixer.SetFloat("soundVol", _soudSlider.value);
    }
}
