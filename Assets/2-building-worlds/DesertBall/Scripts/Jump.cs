using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private float rollPower = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
            rb.AddForceY(jumpPower, ForceMode2D.Impulse);
        else
        {
            if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && IsGrounded())
                rb.AddForceX(rollPower, ForceMode2D.Force);
            if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && IsGrounded())
                rb.AddForceX(-rollPower, ForceMode2D.Force);
        }
    }

    bool IsGrounded()
    {
        int layermask = LayerMask.GetMask("Ground");
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.55f, layermask))
            return true;
        return false;
    }
}
