using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Rocket : MonoBehaviour 
{
    private const int COLLISION_SIZE = 128;
    [SerializeField] private float _powerExplosion;
    [SerializeField] private float _scale;

    private Rigidbody _rigidbody;
    private readonly Collider[] _collidedObjects = new Collider[COLLISION_SIZE];
    private readonly ExplosionFactory _explosionFactory = new ExplosionFactory();

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _explosionFactory.Create();
        Destroy(gameObject);
        float radius = _scale * 0.5f;
        Vector3 center = other.contacts[0].point;
        int countCollied = Physics.OverlapSphereNonAlloc(center, radius, _collidedObjects);

        for (int i = 0; i < countCollied; i++)
        {
            Collider collidedObject = _collidedObjects[i];

            if (collidedObject.TryGetComponent(out HealthController healthController))
            {
                if (healthController.CanTakeDamage(healthController.MaxHp))
                {
                    return;
                }
                if (healthController.TryGetComponent(out Rigidbody rigidbody) == false)
                {
                    rigidbody = healthController.AddComponent<Rigidbody>();
                }
                rigidbody.AddExplosionForce(_powerExplosion, center, radius);
            }
        }
    }
    public void Run(Vector3 path)
    {
        transform.SetParent(null);
        _rigidbody.WakeUp();
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(path, ForceMode.Impulse);
    }
    public void Sleep(Vector3 startPoint)
    {
        _rigidbody.Sleep();
        _rigidbody.isKinematic = true;
        transform.position = startPoint;
    }
}
    

