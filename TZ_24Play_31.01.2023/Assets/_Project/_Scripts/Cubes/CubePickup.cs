using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubePickup : MonoBehaviour
{
    private Transform _parent;

    private void Awake()
    {
        _parent = transform.parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log(collision.gameObject.name);
            var obstacleParent = collision.gameObject.transform.parent;
            collision.gameObject.layer = LayerMask.NameToLayer("ObstacleTuched");
            _parent.parent = null;

            Actions.OnObstacleCollide?.Invoke();

            Destroy(_parent.gameObject, 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            var pickedCube = gameObject;
            pickedCube.layer = LayerMask.NameToLayer("CubePicked");
            pickedCube.GetComponent<Rigidbody>().isKinematic = false;

            
            var cubeHolder = other.transform.GetChild(1);
            _parent.parent = cubeHolder;

            _parent.transform.localPosition = new Vector3(0, cubeHolder.transform.childCount - 1, 0);

            Actions.OnCubePickup?.Invoke();
        }
    }
}
