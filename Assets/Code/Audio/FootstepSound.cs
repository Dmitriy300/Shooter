using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioClip footstepClip; 
    private AudioSource _audioSource;
    private CharacterController _characterController;
    private float _stepDelay = 0.5f; 
    private float _stepTimer;

    void Start()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = footstepClip;
        _audioSource.loop = false;

        _characterController = GetComponent<CharacterController>();
        _stepTimer = _stepDelay; 
    }

    void Update()
    {
        
        if (_characterController.isGrounded && _characterController.velocity.magnitude > 0)
        {
            _stepTimer += Time.deltaTime; 

            if (_stepTimer >= _stepDelay)
            {
                
                _audioSource.PlayOneShot(footstepClip);
                _stepTimer = 0f; 
            }
        }
    }

}
