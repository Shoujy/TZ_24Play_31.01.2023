using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField] private float _trackLifeTime = 10.5f;

    private bool _isGameOver = false;


    private void Start()
    {

        Destroy(gameObject, _trackLifeTime);
    }

    private void Update()
    {
        if (_isGameOver)
        {
            StopAllCoroutines();
        }
    }

    private void OnEnable()
    {
        Actions.OnGameEnd += GameEnd;
    }

    private void OnDisable()
    {
        Actions.OnGameEnd -= GameEnd;
    }


    private void GameEnd()
    {
        _isGameOver = true;
    }
}
