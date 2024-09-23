using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Gun : Weapon
{
    [SerializeField] private int _countInClip;
    [SerializeField] private Bullet _bulletPrefab;

    private Transform _bulletRoot;
    private Queue<Bullet> _bullets ;

    protected override void Start()
    {
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

