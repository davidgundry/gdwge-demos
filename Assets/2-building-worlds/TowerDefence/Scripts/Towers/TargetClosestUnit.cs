using UnityEngine;

[RequireComponent(typeof(Target))]
public class TargetClosestUnit : MonoBehaviour
{
    private Target target;
    public float range = 1f;

    void Start()
    {
        this.target = GetComponent<Target>();
    }

    void Update()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
        if (units.Length > 0)
        {
            float closestDistance = float.PositiveInfinity;
            int closest = 0;
            for (int i = 0; i < units.Length; i++)
            {
                float dist = (transform.position - units[i].transform.position).magnitude;
                if (dist < closestDistance)
                {
                    closest = i;
                    closestDistance = dist;
                }
            }
            if ((units[closest].transform.position - transform.position).magnitude < range)
                this.target.target = units[closest];
            else
                this.target.target = null;
        }
        else
            this.target.target = null;
    }

    
}
