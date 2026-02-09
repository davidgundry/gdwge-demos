using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(DistanceToGround))]
[RequireComponent(typeof(Rigidbody))] // Marked as IsKinematic
[RequireComponent(typeof(PlayerInput))] // Configured to use SendMessages and call OnMove()
public class AccelerateOnInput : MonoBehaviour
{
    [SerializeField] private float acceleration = 5f;

    private Vector3 velocity;
    
    private Vector2 input;
    private Rigidbody rb;
    private DistanceToGround distanceToGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<DistanceToGround>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, direction);
        velocity += direction * acceleration * Time.fixedDeltaTime;

        if (!distanceToGround.Grounded)
            velocity += Vector3.down * 9.81f * Time.fixedDeltaTime;
        else
            velocity = new Vector3(velocity.x, 0, velocity.y);

        Vector3 newPosition = rb.position + velocity * Time.deltaTime;

        rb.MovePosition(newPosition);
        rb.MoveRotation(rotation);
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
}
