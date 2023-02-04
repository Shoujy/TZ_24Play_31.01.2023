using UnityEngine;

public class TrackTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Actions.OnTrackEndTrigger?.Invoke();
            Destroy(gameObject);
        }
    }
}
