using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerCharacterController : MonoBehaviour
{
    // private Vector3 velocity;
    Rigidbody rb;
    CharacterController cc;
    [SerializeField] private float speed = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this.rb = GetComponent<Rigidbody>();
        this.cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        cc.Move(input * Time.deltaTime * speed);
        cc.Move(Vector3.down * 10 * Time.deltaTime);
        // rb.AddForce(input * speed, ForceMode.VelocityChange);
        // // rb.linearVelocity = input * speed;
        // if (rb.linearVelocity.x > input.x * speed || rb.linearVelocity.x < -input.x * speed)
        //     rb.linearDamping = 100;
        // else
        //     rb.linearDamping = 0;

        // if (Input.GetKeyDown("e"))
        //     rb.AddForce(new Vector3(0, 10, 0), ForceMode.VelocityChange);

    }
}
