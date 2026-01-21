using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))] // Marked as IsKinematic
[RequireComponent(typeof(PlayerInput))] // Configured to use SendMessages and call OnMove()
public class MoveIfNotCollide : MonoBehaviour
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

        Vector3 halfExtents = box.bounds.extents / 2f;

        rb.MoveRotation(rotation);
        if (!Physics.BoxCast(rb.position, halfExtents, direction, rb.rotation, distance + halfExtents.z))
            rb.MovePosition(newPosition);
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
}
