using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    [SerializeField] private ParticleSystem _cubePickupParticle;
    [SerializeField] private GameObject _collectCubeText;
    private Rigidbody _playerBodyRB;

    private void Awake()
    {
        _playerBodyRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Actions.OnCubePickup += Jump;
    }

    private void OnDisable()
    {
        Actions.OnCubePickup -= Jump;
    }

    private void Jump()
    {
        Instantiate(_cubePickupParticle, transform.position, Quaternion.identity);
        Instantiate(_collectCubeText, transform.position, Quaternion.identity);
        transform.Translate(0, 1, 0);
    }
}
