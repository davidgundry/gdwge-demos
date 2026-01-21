using UnityEngine;

[RequireComponent(typeof(Target))]
public class RotateToTarget : MonoBehaviour
{
    [SerializeField] private Vector3 initialRotation;

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
            transform.rotation = Quaternion.FromToRotation(initialRotation, direction);
        }
    }

}
