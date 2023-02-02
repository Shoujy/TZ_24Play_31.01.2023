using System.Collections;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _followSpeed;

    private float _shakeDuration = 0.15f;

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

    private void TargetFollow()
    {
        var currentPosition = transform.position;
        var targetPosition = new Vector3(0, 0, _target.position.z);
        transform.position = Vector3.Lerp(currentPosition, targetPosition, _followSpeed * Time.deltaTime);
    }

    private void CameraShake()
    {
        StartCoroutine(Shake(_shakeDuration));
        
    }

    private IEnumerator Shake(float duration)
    {
        var initialRotation = transform.rotation;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float shakeAmount = Mathf.PerlinNoise(Time.time * 10.0f, 0f) * 3.0f;
            transform.rotation = initialRotation * Quaternion.Euler(shakeAmount, 0, 0);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
