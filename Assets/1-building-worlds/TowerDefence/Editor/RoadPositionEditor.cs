using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoadPosition))]

public class RoadPositionEditor : Editor {

    public override void OnInspectorGUI()
    {
        if (DrawDefaultInspector())
        {
            RoadPosition rp = (RoadPosition)target;
            if (rp.road != null)
            {
                if (rp.node >= rp.road.spline.GetPointCount())
                    rp.node = rp.road.spline.GetPointCount() - 1;
            }
        }
    }


    void OnSceneGUI()
    {
        RoadPosition rp = (RoadPosition)target;
        Handles.DrawWireDisc(rp.GetNodePosition(), new Vector3(0, 0, -1), 0.5f);
        Handles.DrawLine(rp.transform.position, rp.GetNodePosition());
    }
	
}