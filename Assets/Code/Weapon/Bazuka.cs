
using UnityEngine;

public sealed class Bazuka : Weapon
{
    [SerializeField] private Rocket _rocketPrefab;
    [SerializeField] private AudioClip _fireSound;
    
    private AudioSource _audioSource;
    private Rocket _instantiateRocket;

    private void Awake()
    {
        // Получаем или добавляем компонент AudioSource к объекту
        _audioSource = gameObject.GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public override void Fire()
    {

        if (_instantiateRocket)
        {
            _instantiateRocket.Run(_barrel.forward * Force);
            _instantiateRocket = null;

            if (_fireSound != null)
            {
                _audioSource.PlayOneShot(_fireSound);
            }
        }
    }

    public override void Recharge()
    {
        if (_instantiateRocket != null)
        {
            return;
        }
        _instantiateRocket = Instantiate(_rocketPrefab, _barrel);
        _instantiateRocket.Sleep(_barrel.position);
    }
}
