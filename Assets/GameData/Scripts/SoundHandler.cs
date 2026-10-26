using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    public AudioSource[] sfx;
    public AudioClip[] sounds;
    public AudioSource bgm;
    [HideInInspector]
    public AudioSource mySource;
    public AudioSource firstAudio, supportingAudio;
    public AudioClip click,tap;
    public static SoundHandler instance;
    private void Awake()
    {
        mySource = GetComponent<AudioSource>();
        instance = this;
    }
    public void SetAllSfx(float sfxV)
    {
        for(int i=0;i<sfx.Length;i++)
        {
            sfx[i].volume=sfxV;
        }
    }
    public void PlaySourceClip(AudioClip c)
    {
        if (PlayerPrefs.GetInt("sfxVolume") >= 0)
        {
            mySource?.PlayOneShot(c);
        }
    }
    public void PlayFirstClip(AudioClip c)
    {
        if (PlayerPrefs.GetInt("sfxVolume") >= 0&&!firstAudio.isPlaying)
        {
            firstAudio.clip = c;
            firstAudio?.Play();
        }
    }
    public void PlaySourceClip2(AudioClip c)
    {
        if (PlayerPrefs.GetInt("sfxVolume") >= 0&& !supportingAudio.isPlaying)
        {
            supportingAudio.clip = c;
            supportingAudio?.Play();
        }
    }
    public void PlaySource(int index)
    {
        if (PlayerPrefs.GetInt("sfxVolume") >= 0)
        {
            mySource?.PlayOneShot(sounds[index]);
        }
    }
    
    public void PlayClick()
    {
        if (PlayerPrefs.GetInt("sfxVolume") >= 0)
        {
            PlaySourceClip(click);
        }
    }

    public void PlayTap()
    {
        if (PlayerPrefs.GetInt("sfxVolume") >= 0)
        {
            PlaySourceClip(tap);
        }
    }
}
