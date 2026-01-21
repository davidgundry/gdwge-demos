using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TargetClosestUnit))]

public class TargetClosestUnitEditor : Editor {

    void OnSceneGUI()
    {
        TargetClosestUnit self = (TargetClosestUnit)target;
        Handles.color = Color.red;
        Handles.DrawWireDisc(self.transform.position, new Vector3(0, 0, -1), self.range);

        Target t = self.GetComponent<Target>();
        if (t)
        {
            if (t.target != null)
            {
                Handles.DrawWireDisc(t.target.transform.position, new Vector3(0, 0, -1), 0.5f);
                Handles.DrawLine(t.target.transform.position, self.transform.position);
            }
        }
    }
	
}