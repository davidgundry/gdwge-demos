using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(WallGenerator))]
public class WallGeneratorEditor : Editor {

    Tool LastTool = Tool.None;
 
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
        WallGenerator t = (WallGenerator)target;

        Vector3 origin = Handles.PositionHandle(t.transform.position, Quaternion.identity);
        if (origin != t.transform.position)
        {
            t.Refresh();
            t.transform.position = new Vector3(origin.x, t.transform.position.y, origin.z);
        }

        Vector3 end = Handles.PositionHandle(t.end, Quaternion.identity);
        if (end != t.end)
        {
            t.Refresh();
            t.end = new Vector3(end.x, t.transform.position.y, end.z);
        }
        Handles.DrawDottedLine(t.transform.position, t.end, 3);
        Handles.DrawDottedLine(t.transform.position, t.transform.position + Vector3.up * t.height, 3);
        Handles.DrawDottedLine(t.end, t.end + Vector3.up * t.height, 3);
        Handles.DrawDottedLine(t.transform.position + Vector3.up * t.height, t.end + Vector3.up * t.height , 3);

        Vector3 midpoint = (t.transform.position + t.end)/2;
        Handles.Label(midpoint, "Length: " + t.Length);

        float newHeight = (float)Handles.ScaleValueHandle(t.height, 
            midpoint + Vector3.up * t.height, 
            Quaternion.Euler(new Vector3(-90,0,0)), 10, Handles.ArrowHandleCap, 0.5f);
        if (newHeight != t.height)
        {
            t.height = newHeight;
            t.Refresh();
        }
    }

    public override void OnInspectorGUI()
    {
        if (DrawDefaultInspector())
        {
            WallGenerator t = (WallGenerator)target;
            t.Refresh();
        }
    }

}