using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _lifeTime = 7.0f;
    [SerializeField] private BulletProjectorData[] _bulletHoles;

    private BulletProjectorHelper _projectorHelper;

    public bool IsActive
    {
        get
        {
            return _isActive;
        }
    }
    
    private Rigidbody _rigidbody;
    private bool _isActive;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _projectorHelper = new BulletProjectorHelper(_bulletHoles);
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
                _projectorHelper.CreateBulletHole(other.contacts[0].point, other.contacts[0].normal, other.transform);
                return;
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
        transform.SetParent(null);
        gameObject.SetActive(true);
        _rigidbody.WakeUp();
        _rigidbody.AddForce(path, ForceMode.Impulse);
        _isActive = true;
        StartCoroutine(Die() );
    }

    public void Sleep()
    {
        _rigidbody.Sleep();
        gameObject.SetActive(false);
        _isActive = false;

    }
    private IEnumerator Die()
    {
        while (_lifeTime >= 0.0f)
        {
            _lifeTime -= 1.0f;
            yield return new WaitForSeconds(1.0f);
        }
        Destroy(gameObject);
    }
}
