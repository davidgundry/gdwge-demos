using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ImprovedFollowPath : MonoBehaviour
{
    [SerializeField] private Waypoints waypoints;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float waypointRadius = 1f;
    [SerializeField]private int currentWaypoint;

    private new Rigidbody rigidbody;
    private Vector3 GetNextWaypoint() { return waypoints.Get(currentWaypoint); }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (GetNextWaypoint() - transform.position).normalized;
        Vector3 desiredVelocity = direction * maxSpeed;
        Vector3 steeringForce = desiredVelocity - rigidbody.linearVelocity;
        rigidbody.AddForce(steeringForce, ForceMode.VelocityChange);

        if (DistanceToWaypointWithin(waypointRadius))
            currentWaypoint = Math.Min(currentWaypoint+1, waypoints.GetLength()-1);
    }

    private bool DistanceToWaypointWithin(float radius)
    {
        return (GetNextWaypoint() - rigidbody.position).sqrMagnitude < radius * radius;
    }
}