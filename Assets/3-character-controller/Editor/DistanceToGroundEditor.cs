using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DistanceToGround))]

public class DistanceToGroundEditor : Editor {

    public override void OnInspectorGUI()
    {
        DistanceToGround d = (DistanceToGround) target;
        GUILayout.Label("DistanceFromFeet: " + d.DistanceFromFeet);
        GUILayout.Label("DistanceFromCenter: " + d.DistanceFromCenter);
        DrawDefaultInspector();
    }


    void OnSceneGUI()
    {
        DistanceToGround d = (DistanceToGround) target;
        Vector3 feet = d.transform.position - new Vector3(0, d.HalfHeight, 0);
        Debug.DrawRay(feet, Vector3.down * d.DistanceFromFeet, Color.yellow);
    }
	
}