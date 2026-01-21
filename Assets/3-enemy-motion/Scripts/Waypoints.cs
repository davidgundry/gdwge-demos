using UnityEngine;
using System;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private Vector3[] waypoints;

    public Vector3 Get(int index)
    {
        return waypoints[index];
    }

    public Vector3 Set(int index, Vector3 value)
    {
        return waypoints[index] = value;
    }

    public int GetLength()
    {
        return waypoints.Length;
    }

    public void SetLength(int value)
    {
        Vector3[] newArray = new Vector3[value];
        Array.Copy(waypoints, newArray, Mathf.Min(value, waypoints.Length));
        waypoints = newArray;
    }
}
