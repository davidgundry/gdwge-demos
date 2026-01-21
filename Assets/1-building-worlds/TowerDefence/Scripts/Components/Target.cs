using UnityEngine;

public class Target : MonoBehaviour
{
    [HideInInspector] public GameObject target;

    public Vector3 GetVectorTo()
    {
        if (target)
            return target.transform.position - transform.position;
        return new Vector3();
    }
}
