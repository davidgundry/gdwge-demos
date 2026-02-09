using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Marked as IsKinematic, in Physics settings, enable all contact pairs
public class KinematicRestitution : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (enabled)
            rb.position = rb.position + collision.relativeVelocity * Time.fixedDeltaTime;
    }

    void OnCollisionStay(Collision collision)
    {
        if (enabled)
            rb.position = rb.position + collision.relativeVelocity * Time.fixedDeltaTime;
    }
}
