using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WeaponData), menuName = "Data/Weapon/Data")]
public sealed class WeaponData : ScriptableObject
{
    [SerializeField] private float _force;
    [SerializeField] private float _shotDelay;

    public float Force 
    { 
        get { return _force; }
    }

    public float ShotDelay 
    { 
        get { return _shotDelay; } 
    }
}
