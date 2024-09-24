using UnityEngine;

public sealed class WeaponSelector 
{
    private int _currentWeaponIndex;
    private Weapon _currentWeapon;

    private readonly Weapon[] _weapons;

    public WeaponSelector(Weapon[] weapons)
    {  
        _weapons = weapons; 
    }

    public void Fire()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.Fire();
        }
    }

    public void Recharge()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.Recharge();
        }
    }

    public void Next()
    {
        _currentWeaponIndex++;
        SelectWeapon();
    }
    
    public void Preview()
    {
        _currentWeaponIndex--;
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        if (_currentWeapon != null)
        {
            _currentWeapon.SetActive(false);
        }
        int index = Mathf.Abs(_currentWeaponIndex % _weapons.Length);
        _currentWeapon = _weapons[index];
        _currentWeapon.SetActive(true);
    }

}

