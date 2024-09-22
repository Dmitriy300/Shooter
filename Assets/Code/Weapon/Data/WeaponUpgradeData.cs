using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponUpgradeData), menuName = "Data/Weapon/Upgrade")]
public class WeaponUpgradeData : ScriptableObject
{
    [Serializable]
    private class WeaponDataByLevel
    {
        public int Level;
        public WeaponData Data;

    }

    [SerializeField] private WeaponDataByLevel[] _weaponData;
    [SerializeField] private WeaponData _weaponDataDefault;

    public WeaponData WeaponDataDefault
    {
        get
        {
            return _weaponDataDefault;
        }
    }

    public bool TryGetWeaponData(int level, out WeaponData weaponData)
    {
        for (var index = 0; index < _weaponData.Length; index++)
        {
            WeaponDataByLevel data = _weaponData[index];
            if (data.Level == level)
            {
                weaponData = data.Data;
                return true;
            }
        }
        weaponData = default;
        return false;
    }
}
