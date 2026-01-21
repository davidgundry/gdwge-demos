using UnityEngine;

[RequireComponent(typeof(RoadPosition))]
public class FollowRoad : MonoBehaviour
{
    private RoadPosition roadPosition;
    private Vector3 target;
    [SerializeField] private float speed;

    void Start()
    {
        roadPosition = GetComponent<RoadPosition>();
        target = transform.position;
    }

    void Update()
    {
        if (roadPosition.IsAtNode() && !roadPosition.IsAtEnd())
        {
            roadPosition.node++;
            target = roadPosition.GetNodePosition();
        }

        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * Time.deltaTime * speed;
    }

}
