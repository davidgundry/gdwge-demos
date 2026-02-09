using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))] // Configured to use SendMessages and call OnMove()
public class ApplyForcesOnInput : MonoBehaviour
{
    [SerializeField] private float deltaVelocityPerSecond = 10f; 
    [SerializeField] private float maxVelocity = 20f; 
    [SerializeField] private float terminalVelocity = 50f; 

    private Vector2 input;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.maxLinearVelocity = terminalVelocity;
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.x, 0, input.y);

        Vector2 moveVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.z);
        if (moveVelocity.sqrMagnitude < maxVelocity * maxVelocity)
        {
            // If mass = 1, all of these lines do the same thing
            rb.AddForce(direction * deltaVelocityPerSecond * Time.fixedDeltaTime, ForceMode.VelocityChange);
            // rb.AddForce(direction * deltaVelocityPerSecond * Time.fixedDeltaTime, ForceMode.Impulse); // will be affected by mass
            // rb.AddForce(direction * deltaVelocityPerSecond, ForceMode.Acceleration);
            // rb.AddForce(direction * deltaVelocityPerSecond, ForceMode.Force); // will be affected by mass
        }
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }
}