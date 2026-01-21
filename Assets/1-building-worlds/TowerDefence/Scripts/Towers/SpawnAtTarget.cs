using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Target))]
public class SpawnAtTarget : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float delay = 5f;

    private Target target;

    void Start()
    {
        target = GetComponent<Target>();
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            if (target.target)
            {
                SpawnProjectileAt(target.target);
                yield return new WaitForSeconds(delay);
            }
            yield return null;
        }
    }

    private void SpawnProjectileAt(GameObject target)
    {
        GameObject spawned = Instantiate(prefab);
        spawned.transform.position = transform.position + new Vector3(0,0,-1);
        Target t;
        spawned.TryGetComponent<Target>(out t);
        if (t)
            t.target = target;
        BroadcastMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
    }

}
