
using UnityEngine;

public class End : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Time.timeScale = 0f;
    }
}
