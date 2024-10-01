using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public AudioClip deathSound; 
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = deathSound;
    }

    private void OnCollisionEnter(Collision collision)
    {
               
        if (collision.gameObject.CompareTag("Obstacle")) 
        {
            
            _audioSource.PlayOneShot(deathSound);

            
            Destroy(gameObject, _audioSource.clip.length);
        }

    }
}
