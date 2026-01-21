using UnityEngine;
using System;

[CreateAssetMenu(fileName = "SpawnPattern", menuName = "ScriptableObjects/SpawnPattern", order = 1)]
public class SpawnPattern : ScriptableObject
{
    public Line[] lines;

    public int index = 0;

    public void Reset()
    {
        this.index = 0;
    }
    

    public Line GetNext()
    {
       
        if (index < lines.Length)
        {
            Line toReturn = lines[index];
            index++;
            return toReturn;
        }
        return null;
    }

    [Serializable]
    public class Line
    {
        public GameObject[] prefabs;
        public float delayBetween;
        public int repeat;
        public float delayOnRepeat;
        public float delayAfter;
    }

}
