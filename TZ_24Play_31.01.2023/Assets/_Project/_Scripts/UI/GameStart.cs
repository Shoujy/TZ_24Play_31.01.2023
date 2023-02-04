using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    [SerializeField] private PlayerControler _playerControler;
    [SerializeField] private List<Track> _tracks;
    [SerializeField] private GameObject _warpEffect;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        _playerControler.enabled = true;

        for (int i = 0; i < _tracks.Count; i++)
        {
            _tracks[i].enabled = true;
        }

        _warpEffect.SetActive(true);

        gameObject.SetActive(false);
    }
}
