using UnityEngine;

[RequireComponent(typeof(Value))]
public class SetValueFromLevelDefence : MonoBehaviour
{
    private Value value;
    private LevelStateSingleton levelState;

    void Start()
    {
        value = GetComponent<Value>();
        levelState = FindFirstObjectByType<LevelStateSingleton>();
    }

    void Update()
    {
        value.value = Mathf.Max(0, ((float)levelState.defencePoints) / (float)levelState.maxDefencePoints);
    }
}
