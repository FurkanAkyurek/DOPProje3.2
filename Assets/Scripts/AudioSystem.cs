using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    private AudioSource audiosource;
    private float musicVolume = 0.5f;
    public Slider sliderr;

    void Start()
    {
        sliderr.GetComponent<Slider>();
        audiosource = GetComponent<AudioSource>();
        musicVolume = 0.5f;
        sliderr.value = 0.5f;
    }

    void Update()
    {
        audiosource.volume = musicVolume;
        
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
