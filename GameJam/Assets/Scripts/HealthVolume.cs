using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthVolume : MonoBehaviour
{
    [SerializeField] int _healthToAdd = 1;
    [SerializeField] GameObject _healthVolume = null;

    [SerializeField] Vector3 _rotation;
    [SerializeField] float _speed;

    [SerializeField] ParticleSystem _collectParticle = null;

    public PlayerHealth _playerHealth = null;

    private void Update()
    {
        transform.Rotate(_rotation * _speed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        CharacterController player = other.GetComponent<CharacterController>();
        if (player != null)
        {
            _playerHealth.AddHealth(_healthToAdd);

        }
        _collectParticle.Play();
        //_healthVolume.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        _healthVolume.SetActive(false);
    }
}
