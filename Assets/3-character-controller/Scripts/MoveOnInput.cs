using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))] // Marked as IsKinematic
[RequireComponent(typeof(PlayerInput))] // Configured to use SendMessages and call OnMove()
public class MoveOnInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 input;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);
        Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, direction);
        Vector3 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
        rb.MoveRotation(rotation);
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
}
