using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float acceleration = 10;
    // private Vector3 velocity;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        rb.AddForce(rb.rotation * Vector3.forward * inputY * acceleration, ForceMode.VelocityChange);
        rb.AddTorque(new Vector3(0, inputX, 0));
        // this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
    }
}
