using System;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private float _moveBorder = 2.0f;

    private float _forwardSpeed = 10.0f;
    private float _slideSpeed = 4.0f;

    private void OnEnable()
    {
        Actions.OnObstacleCollide += ShowPlayerPosition;
    }

    private void OnDisable()
    {
        Actions.OnObstacleCollide += ShowPlayerPosition;
    }

    private void Update()
    {
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

    private void ShowPlayerPosition()
    {
        Debug.Log(transform.position);
    }
}
