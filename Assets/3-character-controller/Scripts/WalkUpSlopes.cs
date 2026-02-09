using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))] // Marked as IsKinematic
[RequireComponent(typeof(PlayerInput))] // Configured to use SendMessages and call OnMove()
public class WalkUpSlopes : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 input;
    private Rigidbody rb;
    private BoxCollider box;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, direction);
        float distance = speed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + direction * distance;

        Vector3 halfExtents = box.bounds.extents;

        float fallRate = 1 * Time.fixedDeltaTime;

        float snapY = newPosition.y;
        RaycastHit hit;
        if (Physics.Raycast(newPosition, Vector3.down, out hit, halfExtents.y + 0.2f))
            snapY = hit.point.y + halfExtents.y;
        else snapY -= fallRate;

        newPosition = new Vector3(newPosition.x, snapY, newPosition.z);

        rb.MoveRotation(rotation);
        if (!Physics.Raycast(rb.position, direction, distance + halfExtents.z))
            rb.MovePosition(newPosition);
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
}
