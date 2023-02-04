using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tracks;
    [SerializeField] private GameObject _player;

    private float _moveTime = 0.80f;

    private float _offsetZ = 60.0f;

    private void OnEnable()
    {
        Actions.OnTrackEndTrigger += SpawnTrack;
    }

    private void OnDisable()
    {
        Actions.OnTrackEndTrigger -= SpawnTrack;
    }

    private void SpawnTrack()
    {
        var positionZ = MathF.Round(_player.transform.position.z * 0.1f, MidpointRounding.ToEven) * 10;
        var spawnPosition = new Vector3(0, 0, positionZ + _offsetZ);
        var randomTrack = UnityEngine.Random.Range(0, _tracks.Count);

        var newTrack = Instantiate(_tracks[randomTrack], spawnPosition - new Vector3(0, 5.0f, 0), Quaternion.identity);

        newTrack.transform.DOMove(spawnPosition, _moveTime);
    }
}
