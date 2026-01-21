using UnityEngine;

public class DistanceToGround : MonoBehaviour
{
    [SerializeField] private float halfHeight;
    private float distance;

    public float DistanceFromCenter { get { return distance + halfHeight; } }
    public float DistanceFromFeet { get { return distance; } }
    public float HalfHeight { get { return halfHeight; } }
    public bool Grounded { get { return DistanceFromFeet < 0.01f; } }

    void Update() {
        RaycastHit hit;
        Vector3 feet = transform.position - new Vector3(0, halfHeight, 0);
        if (Physics.Raycast(feet, Vector3.down, out hit, Mathf.Infinity))
        {
            distance = hit.distance;
        }
        else
            distance = Mathf.Infinity;
    }
}