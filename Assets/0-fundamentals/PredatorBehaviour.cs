using UnityEngine;

public class PredatorBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float eatRange = 1.5f;
    [SerializeField] private float timeToEat = 2f;
    private float eatingTime;
    private GameObject target;

    void Update()
    {
        if (!target)
            target = FindClosestTarget();

        if (target)
        {
            Vector3 direction = target.transform.position - transform.position;
            float distance = direction.magnitude;
            if (distance > eatRange)
            {
                direction = new Vector3(direction.x, 0, direction.z).normalized;
                transform.Translate(direction * speed * Time.deltaTime);
                eatingTime = 0;
            }
            else
            {
                eatingTime += Time.deltaTime;
                if (eatingTime > timeToEat)
                {
                    Destroy(target.gameObject);
                    target = null;
                }
            }
        }
    }

    private GameObject FindClosestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < targets.Length; i++)
        {
            GameObject t = targets[i];
            float squareDistance = (t.transform.position - transform.position).sqrMagnitude;
            if (squareDistance < closestDistance)
            {
                closest = t;
                closestDistance = squareDistance;
            }
        }
        return closest;
    }
}
