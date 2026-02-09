using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(DistanceToGround))]
public class JumpOnInput : MonoBehaviour
{
    [SerializeField] private float deltaVelocity = 10f; 
    private bool jump;
    private Rigidbody rb;
    private DistanceToGround distanceToGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distanceToGround = GetComponent<DistanceToGround>();
    }

    void FixedUpdate()
    {
        if (jump && distanceToGround.Grounded)
        {
            rb.AddForce(Vector3.up * deltaVelocity, ForceMode.Impulse); // affected by mass
            jump = false;
        }
    }

    public void OnJump(InputValue value)
    {
        jump = value.isPressed;
    }
}
