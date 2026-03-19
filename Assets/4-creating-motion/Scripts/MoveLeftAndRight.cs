using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveLeftAndRight : MonoBehaviour
{
    [Serializable]
    public struct Bounds {
        public float left;
        public float right;
    }
    private new Rigidbody rigidbody;
    private bool goingRight = false;
    [SerializeField] private Bounds bounds = new Bounds { left = -5.0f, right = 5.0f };

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (goingRight)
            rigidbody.linearVelocity = Vector3.right;
        else
            rigidbody.linearVelocity = Vector3.left;

        if (transform.position.x >= bounds.right)
            goingRight = false;
        if (transform.position.x <= -bounds.left)
            goingRight = true;
    }

}
