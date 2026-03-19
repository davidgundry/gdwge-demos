using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoints))]
public class WaypointsEditor : Editor
{
    private Tool LastTool = Tool.None;
    void Awake()
    {
        ((MonoBehaviour)target).transform.hideFlags = HideFlags.HideInInspector;
        ((MonoBehaviour)target).gameObject.isStatic = true;
    }
	void OnEnable()
	{
		LastTool = Tools.current;
		Tools.current = Tool.None;
	}

	void OnDisable()
	{
		Tools.current = LastTool;
	}

    void OnSceneGUI()
    {
        Waypoints waypoints = (Waypoints)target;
        for (int i = 0; i < waypoints.GetLength(); i++)
        {
            Vector3 original = waypoints.Get(i);
            Vector3 updated = Handles.PositionHandle(original, Quaternion.identity);
            if (original != updated)
                waypoints.Set(i, updated);
            if (i > 0)
                Handles.DrawDottedLine(waypoints.Get(i - 1), updated, 0.1f);
        }
    }
}