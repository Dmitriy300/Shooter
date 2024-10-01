using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudioManager : MonoBehaviour
{
    public AudioClip music;
    private AudioSource _audioSource;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _audioSource.volume = 0.7f;
        _audioSource.clip = music;
        _audioSource.Play();



    }
}
