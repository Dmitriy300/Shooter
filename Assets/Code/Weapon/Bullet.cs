using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
   [SerializeField] private float _force;
    private Rigidbody _rigidbody;
    private bool _isActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnBecameInvisible()
    {
        if (_isActive == false)
        {
            return;
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if (other.collider.TryGetComponent(out HealthController healthController))
        {
            if (healthController.CanTakeDamage(1))
            {
                return ;
            }

           if (other.collider.TryGetComponent(out Rigidbody rigidbody) == false)
            {
               rigidbody = other.collider.AddComponent<Rigidbody>();
            }
            rigidbody.AddForce(_rigidbody.velocity * _force, ForceMode.Impulse);
        }
    }
    public void Run(Vector3 path, Vector3 startPosition)
    {
        transform.position = startPosition;
        gameObject.SetActive(true);
        _rigidbody.WakeUp();
        _rigidbody.AddForce(path, ForceMode.Impulse);
        _isActive = true;
    }

    public void Sleep()
    {
        _rigidbody.Sleep();
        gameObject.SetActive(false);
        _isActive = false;
            
    }
}
