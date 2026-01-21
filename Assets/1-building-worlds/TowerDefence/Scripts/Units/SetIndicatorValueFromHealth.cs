using UnityEngine;

[RequireComponent(typeof(UnitHealth))]
public class SetIndicatorValueFromHealth : MonoBehaviour
{
    public Value value;
    private UnitHealth unitHealth;

    void Start()
    {
        unitHealth = GetComponent<UnitHealth>();
    }

    void Update()
    {
        value.value = Mathf.Max(0, ((float) unitHealth.health) / (float) unitHealth.max);
    }
}
