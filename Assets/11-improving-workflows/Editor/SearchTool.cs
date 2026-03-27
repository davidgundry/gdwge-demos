using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class SearchTool : EditorWindow
{
    
    [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

    [MenuItem("Tools/SearchTool")]
    public static void ShowExample()
    {
        SearchTool wnd = GetWindow<SearchTool>();
        wnd.titleContent = new GUIContent("SearchTool");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        root.Add(m_VisualTreeAsset.Instantiate());

        //When the user clicks the search button, it updates the list
        Button searchButton = root.Query<Button>(name="search").First();
        searchButton?.RegisterCallback<ClickEvent>(UpdateList);
    }

    private void UpdateList(ClickEvent evt)
    {
        VisualElement root = rootVisualElement;
        string query = root.Q<TextField>(name = "query").text;

        string area = "all";
        if (root.Q<Toggle>(name = "useAssets")?.value == true)
            area = "assets";
        if (root.Q<Toggle>(name = "usePackages")?.value == true)
            area = "packages";

        string[] guids = AssetDatabase.FindAssets($"{query} a:{area}", null);
        List<string> source = new List<string>();
        foreach (string guid in guids)
            source.Add(AssetDatabase.GUIDToAssetPath(guid));

        ListView listView = root.Q<ListView>();
        listView.Clear();
        listView.makeItem = () => new Label();
        listView.bindItem = (VisualElement elem, int index) => { (elem as Label).text = index < source.Count ? source[index] : ""; };
        listView.itemsSource = source;

        // Callback invoked when the user double clicks an item
        listView.itemsChosen += Debug.Log;

        // Callback invoked when the user changes the selection inside the ListView
        listView.selectionChanged += Debug.Log;
    }
}