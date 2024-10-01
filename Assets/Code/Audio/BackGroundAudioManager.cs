using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudioManager : MonoBehaviour
{
    public AudioClip[] music;

    private AudioSource _audioSource;
    private AudioClip _currentClip;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        StartCoroutine(UpdateBackgroundMusic());
    }
    private IEnumerator UpdateBackgroundMusic()
    {
        if (_currentClip != null)
        {
            yield return new WaitForSeconds(_currentClip.length);
            GenerateRandomMusic();
            PlayRandomBackgroundMusic();
        }
        else
        {
            GenerateRandomMusic();
            PlayRandomBackgroundMusic();
            yield return new WaitForEndOfFrame();
        }
    }
    private void GenerateRandomMusic()
    {
        int randomIndex = Random.Range(0, music.Length);
        _currentClip = music[randomIndex];
    }
    private void PlayRandomBackgroundMusic()
    {
        if (_currentClip != null)
        {
            _audioSource.clip = _currentClip;
            _audioSource.volume = 0.7f;
           
            _audioSource.Play();
            StartCoroutine(UpdateBackgroundMusic());
        }
    }
}
