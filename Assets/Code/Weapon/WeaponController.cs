using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private WeaponSelector _weaponSelector;

    private void Start()
    {
        Weapon[] weapons = gameObject.GetComponentsInChildren<Weapon>(true);
        _weaponSelector = new WeaponSelector(weapons);
    }

    private void Update()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        //if (scrollWheel > 0.1f)
        //{
        //    _weaponSelector.Next();
        //}

        //if (scrollWheel < -0.1f)
        //{
        //    _weaponSelector.Preview();
        //}

        if (Input.GetMouseButton(0))
        {
            _weaponSelector.Fire();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _weaponSelector.Recharge();
        }

        // Переключение оружия на правую кнопку мыши
        if (Input.GetMouseButtonDown(1)) // 1 - это правая кнопка мыши
        {
            _weaponSelector.Next(); // Переключаемся на следующее оружие
        }
    }

}
