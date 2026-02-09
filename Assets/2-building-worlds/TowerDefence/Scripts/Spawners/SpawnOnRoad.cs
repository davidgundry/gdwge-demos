using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RoadPosition))]
public class SpawnOnRoad : MonoBehaviour
{
    private RoadPosition roadPosition;
    [SerializeField] private float delay = 1f;
    [SerializeField] private GameObject prefab;

    void Start()
    {
        roadPosition = GetComponent<RoadPosition>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject unit = Instantiate(prefab);
            unit.transform.position = roadPosition.GetNodePosition();
            RoadPosition rp;
            unit.TryGetComponent<RoadPosition>(out rp);
            if (rp)
            {
                rp.road = roadPosition.road;
                rp.node = roadPosition.node;
            }
            BroadcastMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
            yield return new WaitForSeconds(delay);
        }
    }
}
