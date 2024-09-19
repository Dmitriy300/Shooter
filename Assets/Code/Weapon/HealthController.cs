using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _health;


    private bool _isAlive = true;

    public bool CanTakeDamage(int damage)
    { 
        if (_isAlive == false)
        {
            return false;
        }

        _health -= damage;
        if (_health <= 0)
        {
            StartCoroutine(Die()); //запуск корутины
            _isAlive = false;
            return false;
        }

        return true;
    }

    //корутина
    private IEnumerator Die()
    {
        Renderer renderer = GetComponent<Renderer>();
        
        renderer.material.color = Color.green;
        yield return new WaitForSeconds(1.0f);

        renderer.material.color = Color.red;
        yield return new WaitForSeconds(1.0f);

        renderer.material.color = Color.magenta;
        yield return new WaitForSeconds(1.0f);
    }
}
