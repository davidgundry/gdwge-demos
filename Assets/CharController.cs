using UnityEngine;
using UnityEngine.InputSystem;

public class CharController : MonoBehaviour
{


    [SerializeField] private float impulse = 1;
    [SerializeField] private float acceleration = 10;
    [SerializeField] private float topSpeed = 10;
    // private Vector3 velocity;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity += rb.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * acceleration;
        if (Input.GetKey("e"))
            rb.linearVelocity = rb.linearVelocity + new Vector3(0, 10, 0);
        // rb.MovePosition(this.transform.position + velocity * Time.deltaTime);
        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

//        velocity.y -= 9.81f * Time.deltaTime;

    }
}
