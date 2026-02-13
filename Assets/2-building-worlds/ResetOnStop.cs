using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ResetOnStop : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private Transform resetPoint;
    [SerializeField] private float waitDuration = 2f;
    [SerializeField] private bool resetting = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitToReset());
    }

    IEnumerator WaitToReset()
    {
        
        float startTime = Time.time;
        while (true)
        {
            while (startTime + waitDuration > Time.time)
            {
                if (IsMoving())
                {
                    resetting = false;
                    yield return new WaitForSeconds(1f);
                    startTime = Time.time;
                }
                resetting = true;
                yield return null;
            }
            transform.position = resetPoint.position;
            yield return new WaitForSeconds(1f);
            startTime = Time.time;
        }
    }

    private bool IsMoving()
    {
        return rb.linearVelocity.magnitude > 0.001f;
    }
}
