using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject _warpEffect;
    [SerializeField] private GameObject _panel;

    [SerializeField] private List<Track> _tracks;

    private void OnEnable()
    {
        Actions.OnGameEnd += EndGame;
    }

    private void OnDisable()
    {
        Actions.OnGameEnd -= EndGame;
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene(0);
    }

    private void EndGame()
    {

        Debug.Log("This end game method!");

        //_tracks = FindObjectsOfType<Track>().ToList();

        //for (int i = 0; i < _tracks.Count - 1; i++)
        //{
        //    _tracks[i].enabled = false;
        //}

        _warpEffect.SetActive(false);

        _panel.SetActive(true);
    }
}
