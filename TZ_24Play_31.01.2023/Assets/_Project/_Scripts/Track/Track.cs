using UnityEngine;

public class Track : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(0, 0, -4 * Time.deltaTime);
    }
}
