using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Shotgun : Weapon
{
    [SerializeField] private int _countInClip;
    [SerializeField] private Fraction _fractionPrefab;
    [SerializeField] private int _pelletCount = 10;
    [SerializeField] private float spreadAngle;

    private Transform _fractionRoot;
    private Queue<Fraction> _fractions;
   
    protected override void Start()
    {
        base.Start();
        _fractions = new Queue<Fraction>(_countInClip);
        _fractionRoot = new GameObject("Fraction").transform;
        Recharge();
    }

    public override void Fire()
    {
        if (CanShoot == false)
        {
            return;
        }

        for (int i = 0; i < _pelletCount; i++)
        {
            if (_fractions.TryDequeue(out Fraction fraction))
            {
                // Генерируем случайный угол разброса
                float spreadX = Random.Range(-spreadAngle, spreadAngle);
                float spreadY = Random.Range(-spreadAngle, spreadAngle);

                Quaternion spreadRotation = Quaternion.Euler(spreadY, spreadX, 0);
                Vector3 fireDirection = spreadRotation * _barrel.forward;

                fraction.Run(fireDirection * Force, _barrel.position);
                LastShootTime = 0.0f;
            }
        }
    
    }
    
    public override void Recharge()
    {
        for (int i = 0; i < _countInClip; i++)
        {
            Fraction fraction = Instantiate(_fractionPrefab, _fractionRoot);
            //fraction.Sleep();
            _fractions.Enqueue(fraction);
        }
    }

    
}
