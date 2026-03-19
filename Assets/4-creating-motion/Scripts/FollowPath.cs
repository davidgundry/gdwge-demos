using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FollowPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float waypointRadius = 1f;
    [SerializeField]private int currentWaypoint;

    private new Rigidbody rigidbody;
    private Transform GetNextWaypoint() { return waypoints[currentWaypoint]; }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (GetNextWaypoint().transform.position - transform.position).normalized;
        Vector3 desiredVelocity = direction * maxSpeed;
        Vector3 steeringForce = desiredVelocity - rigidbody.linearVelocity;
        rigidbody.AddForce(steeringForce, ForceMode.VelocityChange);

        if (DistanceToWaypointWithin(waypointRadius))
            currentWaypoint = Math.Min(currentWaypoint+1, waypoints.Length-1);

    }

    private bool DistanceToWaypointWithin(float radius)
    {
        return (GetNextWaypoint().position - rigidbody.position).sqrMagnitude < radius * radius;
    }
}