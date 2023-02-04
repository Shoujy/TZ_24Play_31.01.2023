using DG.Tweening;
using System.Collections;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;

    private Vector3 _cameraPosition;
    private float _shakeDuration = 0.15f;

    private void Start()
    {
        _cameraPosition = Camera.main.transform.localPosition;
    }

    private void OnEnable()
    {
        Actions.OnObstacleCollide += CameraShake;
    }

    private void OnDisable()
    {
        Actions.OnObstacleCollide -= CameraShake;
    }
    private void LateUpdate()
    {
        TargetFollow();
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void TargetFollow()
    {
        var currentPosition = transform.position;
        var targetPosition = new Vector3(0, 0, _target.position.z);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, _followSpeed * Time.deltaTime);
    }

    private void CameraShake()
    {       
        Camera.main.transform.DOShakePosition(_shakeDuration);
        Camera.main.transform.localPosition = _cameraPosition;
    }
}
