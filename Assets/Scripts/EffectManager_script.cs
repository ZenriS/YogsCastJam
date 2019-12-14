using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectManager_script : MonoBehaviour
{
    private AudioSource _musicSource;
    private AudioSource _sfxSource;
    public Toggle MusicToggle;
    public Toggle SFXToggle;
    public float MusicVolume;
    public float SFXVolume;
    

    void Start()
    {
        _musicSource = GetComponents<AudioSource>()[0];
        _musicSource.volume = MusicVolume;
        _sfxSource = GetComponents<AudioSource>()[1];
        _sfxSource.volume = SFXVolume;
    }

    public void ToggleMusicMute()
    {
        if (MusicToggle.isOn)
        {
            _musicSource.volume = 0;
        }
        else
        {
            _musicSource.volume = MusicVolume;
        }
    }

    public void ToggleSFXMute()
    {
        if (SFXToggle.isOn)
        {
            _sfxSource.volume = 0;
        }
        else
        {
            _sfxSource.volume = SFXVolume;
        }
    }

    public void PlaySFX(AudioClip ac)
    {
        _sfxSource.pitch = Random.Range(0.9f, 1.1f);
        _sfxSource.PlayOneShot(ac);
    }
}
