using System;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _track;
    [SerializeField] private GameObject _player;

    private float _offsetZ = 70.0f;

    private void OnEnable()
    {
        Actions.OnObstacleCollide += SpawnTrack;
    }

    private void OnDisable()
    {
        Actions.OnObstacleCollide -= SpawnTrack;
    }

    private void SpawnTrack()
    {
        var positionZ = MathF.Round(_player.transform.position.z * 0.1f, MidpointRounding.ToEven) * 10;
        var spawnPosition = new Vector3(0, 0, positionZ + _offsetZ);
        Instantiate(_track, spawnPosition, Quaternion.identity);
    }
}
