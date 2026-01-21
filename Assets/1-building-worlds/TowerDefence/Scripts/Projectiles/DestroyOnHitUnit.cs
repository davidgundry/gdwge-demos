using UnityEngine;

public class DestroyOnHitUnit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Unit")
            Destroy(gameObject);
    }
}
