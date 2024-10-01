using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Gun : Weapon
{
    [SerializeField] private int _countInClip;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private AudioClip _shootClip;
    private Transform _bulletRoot;
    private Queue<Bullet> _bullets;

    private AudioSource _audioSource;
    protected override void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        base.Start();
        _bullets = new Queue<Bullet>(_countInClip);
        _bulletRoot = new GameObject("BulletRoot").transform;
        Recharge();
    }

    public override void Fire()
    {
        if (CanShoot == false)
        {
            return;
        }

        if (_bullets.TryDequeue(out Bullet bullet))
        {
            _audioSource.PlayOneShot(_shootClip);
            bullet.Run(_barrel.forward * Force, _barrel.position);
            LastShootTime = 0.0f;
        }
    }

    public override void Recharge()
    {
        for (int i = 0; i < _countInClip; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, _bulletRoot);
            bullet.Sleep();
            _bullets.Enqueue(bullet);
        }
    }
   
}

