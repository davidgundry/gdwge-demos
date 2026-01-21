using UnityEngine;

[RequireComponent(typeof(Target))]
public class DestroyAndSpawnOnReachTarget : MonoBehaviour
{
    private Target target;
    [SerializeField] private GameObject prefab;

    void Start()
    {
        target = GetComponent<Target>();
    }

    private void Update()
    {
        if (target.GetVectorTo().magnitude < 0.1f)
        {
            if (prefab != null)
                Instantiate(prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
