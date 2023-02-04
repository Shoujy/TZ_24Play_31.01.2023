using DG.Tweening;
using UnityEngine;

public class CollectCubeText : MonoBehaviour
{
    private float _lifeTime = 1.0f;
    private float _moveAmountY = 3.0f;
    private float _moveAmountX = 2.0f;
    private float _moveTime = 0.80f;

    private Vector3 _spawnPosition;
    private void Start()
    {
        _spawnPosition = transform.position;

        transform.DOMoveY(_spawnPosition.y + _moveAmountY, _moveTime);
        transform.DOLocalMoveX(_spawnPosition.x - _moveAmountX, _moveTime);

        Destroy(gameObject, _lifeTime);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
