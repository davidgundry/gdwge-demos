using UnityEngine;
using UnityEngine.U2D;

public class RoadPosition : MonoBehaviour
{
    public SpriteShapeController road;
    public int node = 0;

    public Vector3 GetNodePosition()
    {
        if (road)
            return road.spline.GetPosition(node) + road.transform.position + new Vector3(0,0,-1);
        return new Vector3();
    }

    public bool IsAtNode()
    {
        return (transform.position - GetNodePosition()).magnitude < 0.05f;
    }

    public bool IsAtEnd()
    {
        if (road && (node == road.spline.GetPointCount() - 1) && IsAtNode())
            return true;
        return false;
    }
}
