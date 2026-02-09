using UnityEngine;

public class FollowWaypoints : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int currentWaypoint = 0;

    void Update()
    {
        if (DistanceToWaypoint() < 0.5f)
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        else
            MoveTowardsWaypoint();
    }

    private float DistanceToWaypoint()
    {
        return (waypoints[currentWaypoint].position - transform.position).magnitude;
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 direction = waypoints[currentWaypoint].position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z).normalized;
        transform.Translate(direction * 2.4f * Time.deltaTime);
    }
}
