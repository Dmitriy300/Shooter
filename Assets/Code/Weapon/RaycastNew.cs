using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastNew : MonoBehaviour
{
    [SerializeField] private float _distance = 10.0f;
    private void Update()
    {
        First();
    }

    private void First()
    {
       if ( Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            Debug.LogError(hit.collider.gameObject.name);
        }

        Debug.DrawRay(transform.position, transform.forward * _distance, Color.red);
    }
}
