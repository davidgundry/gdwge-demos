using UnityEngine;
using System.Collections;

[RequireComponent(typeof(RoadPosition))]
public class SpawnOnRoadFromPattern : MonoBehaviour
{
    [SerializeField] private SpawnPattern pattern;
    private RoadPosition roadPosition;
    private SpawnPattern.Line spawnLine;

    void Start()
    {
        roadPosition = GetComponent<RoadPosition>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        pattern.Reset();
        while (true)
        {
            SpawnPattern.Line spawnLine = pattern.GetNext();
            if (spawnLine == null)
                break;

            for (int r = 0; r < spawnLine.repeat; r++)
            {
                for (int i = 0; i < spawnLine.prefabs.Length; i++)
                {
                    GameObject unit = Instantiate(spawnLine.prefabs[i]);
                    unit.transform.position = roadPosition.GetNodePosition();
                    RoadPosition rp;
                    unit.TryGetComponent<RoadPosition>(out rp);
                    if (rp)
                    {
                        rp.road = roadPosition.road;
                        rp.node = roadPosition.node;
                    }
                    BroadcastMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
                    yield return new WaitForSeconds(spawnLine.delayBetween);
                }
                yield return new WaitForSeconds(spawnLine.delayOnRepeat);
            }
            yield return new WaitForSeconds(spawnLine.delayAfter);
        }
    }
}
