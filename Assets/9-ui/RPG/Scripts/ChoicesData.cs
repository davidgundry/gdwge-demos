using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[Serializable]
public struct Choice {
    [SerializeField] private string name;
    [SerializeField] private DisplayStyle display;
    [SerializeField] private bool enabled;

    public bool inUse { 
        get { return display == DisplayStyle.Flex; } 
        set { display = value ? DisplayStyle.Flex : DisplayStyle.None; }
    }
}

[CreateAssetMenu(fileName = "ChoicesData", menuName = "Scriptable Objects/ChoicesData")]
public class ChoicesData : ScriptableObject
{
    [SerializeField] private Choice choice0;
    [SerializeField] private Choice choice1;
    [SerializeField] private Choice choice2;
    [SerializeField] private Choice choice3;
    [SerializeField] private Choice choice4;
    [SerializeField] private bool choicesEnabled;
    [SerializeField] private DisplayStyle displaySubchoice;
    [SerializeField] private List<Choice> subChoices;
}
