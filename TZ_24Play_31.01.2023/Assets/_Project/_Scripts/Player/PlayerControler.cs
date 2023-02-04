using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] private GameObject _playerBody;
    [SerializeField] private GameObject _cubeHolder;

    private float _moveBorder = 2.0f;

    private float _forwardSpeed = 10.0f;
    private float _slideSpeed = 4.0f;

    private bool _isGameOver;

    private void Start()
    {
        _isGameOver = false;
    }

    private void OnEnable()
    {
        Actions.OnObstacleCollide += HaveAnyCubes;
    }

    private void OnDisable()
    {
        Actions.OnObstacleCollide += HaveAnyCubes;
    }

    private void Update()
    {
        if (_isGameOver) 
            return;

         transform.Translate(0, 0, _forwardSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            Vector3 mousPosition = Input.mousePosition;
            if (mousPosition.x < Screen.width / 2)
            {
                if(transform.position.x <= -_moveBorder)
                    return;

                transform.position -= transform.right * _slideSpeed * Time.deltaTime;
            }
            else if (mousPosition.x > Screen.width / 2)
            {
                if (transform.position.x >= _moveBorder)
                    return;

                transform.position += transform.right * _slideSpeed * Time.deltaTime;
            }
        }
    }

    private void HaveAnyCubes()
    {
        var childCount = GameObject.Find("CubeHolder").transform.childCount;
        if (childCount <= 0)
        {
            _isGameOver = true;
            Actions.OnGameEnd?.Invoke();
        }
    }
}
