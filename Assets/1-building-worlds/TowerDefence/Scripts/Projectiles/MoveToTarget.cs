using UnityEngine;

[RequireComponent(typeof(Target))]
public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private float speed;

    private Target target;

    void Start()
    {
        this.target = GetComponent<Target>();
    }

    void Update()
    {
        if (this.target)
        {
            Vector3 direction = target.GetVectorTo().normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

}
