using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            playerController.IncrementScore(1);
        }
        Destroy(gameObject);
    }

    
}
