using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int health;
    [SerializeField] private int mana;
    [SerializeField] private Texture2D icon;

    [SerializeField] private DisplayStyle display = DisplayStyle.Flex;
}
