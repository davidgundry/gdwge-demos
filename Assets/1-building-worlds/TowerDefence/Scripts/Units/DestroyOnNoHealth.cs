using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
public class DestroyOnNoHealth : MonoBehaviour
{
    private UnitHealth unitHealth;

    void Start()
    {
        unitHealth = GetComponent<UnitHealth>();
    }

    void Update()
    {
        if (unitHealth.health <= 0)
            Destroy(gameObject);
    }
}
