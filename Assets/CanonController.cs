using UnityEngine;

public class CanonController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private Quaternion rotation = Quaternion.identity;
    private Quaternion barrelRotation = Quaternion.AngleAxis(45, Vector3.right);

    [SerializeField] private Transform barrel;

    void FixedUpdate()
    {
        rotation *= Quaternion.AngleAxis(Input.GetAxis("Mouse X"), Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        barrelRotation *= Quaternion.AngleAxis(-Input.GetAxis("Mouse Y"), Vector3.right);
        barrel.localRotation = Quaternion.Lerp(barrel.localRotation, barrelRotation, rotationSpeed * Time.deltaTime);
    }
}
