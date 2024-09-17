using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public bool _isActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Run(Vector3 path, Vector3 startPosition)
    {
        transform.position = startPosition;
        gameObject.SetActive(true);
        _rigidbody.WakeUp();
        _rigidbody.AddForce(path);
        _isActive = true;
    }

    public void Sleep()
    {
        _rigidbody.Sleep();
        gameObject.SetActive(false);
        _isActive = false;
            
    }
}
