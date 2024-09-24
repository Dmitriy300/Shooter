using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _level = 1;
    [SerializeField] protected Transform _barrel;
    [SerializeField] private WeaponUpgradeData _upgradeData;
    
    protected bool CanShoot {  get; private set; }
    protected float Force {  get; private set; }
    protected float LastShootTime { get; set; }


    private float _shotDelay;

    protected virtual void Start()
    {
        if (_upgradeData.TryGetWeaponData(_level, out WeaponData data))
        {
            _shotDelay = data.ShotDelay;
            Force = data.Force;
        }
        else
        {
            _shotDelay = _upgradeData.WeaponDataDefault.ShotDelay;
            Force = _upgradeData.WeaponDataDefault.Force;
        }
    }

    private void Update()
    {
        CanShoot = _shotDelay <= LastShootTime;

        if (CanShoot)
        {
            return;
        }

        LastShootTime += Time.deltaTime;
    }

    public abstract void Fire();
    public abstract void Recharge();

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }
}
