using UnityEngine;

[RequireComponent(typeof(Value))]
public class SetChildScaleToValue : MonoBehaviour
{
    private Value value;

    void Start()
    {
        value = GetComponent<Value>();
    }

    void Update()
    {
        Transform child = transform.GetChild(0);
        child.localScale = new Vector3(value.value, 1, 1);
        float offsetX = -0.5f * (1 - value.value);
        child.localPosition = new Vector3(offsetX, 0, -1);
    }
}
