using UnityEngine;

public class DamageUnitOnHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Unit")
        {
            UnitHealth h = other.GetComponent<UnitHealth>();
            if (h)
                h.health--;
            other.BroadcastMessage("OnDamaged", SendMessageOptions.DontRequireReceiver);
        }
            
    }
}
