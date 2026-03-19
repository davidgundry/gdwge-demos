using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(ColumnGenerator))]
public class ColumnGeneratorEditor : Editor {
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

    void OnSceneGUI() {
        ColumnGenerator t = (ColumnGenerator)target;

        Vector3 origin = Handles.PositionHandle(t.transform.position, Quaternion.identity);
        if (origin != t.transform.position)
        {
            t.Refresh();
            t.transform.position = new Vector3(origin.x, t.transform.position.y, origin.z);
        }

        Handles.DrawDottedLine(t.transform.position, t.transform.position + Vector3.up * t.height, 3);
        Handles.DrawWireDisc(t.transform.position, Vector3.up, t.radius);
        Handles.DrawWireDisc(t.transform.position + Vector3.up * t.height, Vector3.up, t.radius);


        float newHeight = (float)Handles.ScaleValueHandle(t.height, 
            t.transform.position + Vector3.up * t.height, 
            Quaternion.Euler(new Vector3(-90,0,0)), 10, Handles.ArrowHandleCap, 0.5f);
        if (newHeight != t.height)
        {
            t.height = newHeight;
            t.Refresh();
        }


        Handles.BeginGUI();
 
        if (GUILayout.Button("Refresh"))
            t.Refresh();
 
        Handles.EndGUI();
    }


    public override void OnInspectorGUI()
    {
        if (DrawDefaultInspector())
        {
            ColumnGenerator t = (ColumnGenerator)target;
            t.Refresh();
        }
    }


}