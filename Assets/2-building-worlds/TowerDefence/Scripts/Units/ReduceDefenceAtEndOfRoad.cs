using UnityEngine;

[RequireComponent(typeof(RoadPosition))]
public class ReduceDefenceAtEndOfRoad : MonoBehaviour
{
    private RoadPosition roadPosition;
    private LevelStateSingleton levelState;

    void Start()
    {
        roadPosition = GetComponent<RoadPosition>();
        levelState = FindFirstObjectByType<LevelStateSingleton>();
        if (!levelState)
            Debug.LogWarning("Expects LevelStateSingleton to exist");
    }

    void Update()
    {
        if (roadPosition.road && roadPosition.IsAtEnd())
        {
            if (levelState)
                levelState.defencePoints--;
            Destroy(this.gameObject);
        }
    }
}
