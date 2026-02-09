using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HomingMissile : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float acceleration = 1f;
    [SerializeField] private float maxSpeed = 1f;
    private new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (target != null)
            SeekTarget();
    }

    void SeekTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Vector3 desiredVelocity = direction * maxSpeed;
        Vector3 steeringForce = desiredVelocity - rigidbody.linearVelocity;
        rigidbody.AddForce(steeringForce, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        SendMessage("OnExplode", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
        Destroy(target.gameObject);
    }
}