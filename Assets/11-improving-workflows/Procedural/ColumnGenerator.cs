using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[SelectionBase]
[RequireComponent(typeof(BoxCollider))]
[ExecuteInEditMode]
public class ColumnGenerator : MonoBehaviour
{
    [Serializable]
    struct ColumnPrefabs {
        public GameObject pedestal;
        public GameObject column;
        public GameObject capital;
    }

    private GameObject[] _objects = new GameObject[3];

    [SerializeField] private ColumnPrefabs prefabs = new ColumnPrefabs();

    [Range(1f, 10f)] public float height = 2.0f;
    [Range(0.25f, 5f)] public float radius = 0.5f;
    [SerializeField, Range(0, 1f)] private float pedestalProportion = 0.2f;
    [SerializeField, Range(0, 1f)] private float capitalProportion = 0.1f;
    [SerializeField, Range(0, 1f)] private float columnWidth = 0.8f;

    void Reset()
    {
        if (prefabs.pedestal == null && prefabs.column == null && prefabs.capital == null)
        {
            AsyncOperationHandle<GameObject> opHandle = Addressables.LoadAssetAsync<GameObject>("Procedural/ProBuilderCube.prefab");
            opHandle.WaitForCompletion();
            GameObject cubePrefab = opHandle.Result;
            prefabs.pedestal = cubePrefab;
            prefabs.column = cubePrefab;
            prefabs.capital = cubePrefab;
        }
        Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh() {
        RecreateObjects();
    }

    private void RecreateObjects()
    {        
        for (int i=0;i<_objects.Length;i++)
        {
            if (_objects[i])
                DestroyImmediate(_objects[i]);
            _objects[i] = null;
        }
        _objects= new GameObject[3];

        float pedestalHeight = height * pedestalProportion;
        float columnHeight = height * (1 - (pedestalProportion+capitalProportion));
        float capitalHeight = height * capitalProportion;

        float sideLength = radius * 1.5f;
        
        GameObject pedestalInstance = Instantiate(prefabs.pedestal, transform.position + Vector3.up * pedestalHeight/2, transform.rotation, transform);
        pedestalInstance.transform.localScale = new Vector3(sideLength, pedestalHeight, sideLength);
        pedestalInstance.name = "Pedestal";
        _objects[0] = pedestalInstance;

        GameObject columnInstance = Instantiate(prefabs.column, transform.position + Vector3.up * (pedestalHeight + columnHeight/2), transform.rotation, transform);
        columnInstance.transform.localScale = new Vector3(sideLength * columnWidth, columnHeight, sideLength*columnWidth);
        columnInstance.name = "Column";
        _objects[1] = columnInstance;

        GameObject capitalInstance = Instantiate(prefabs.capital, transform.position + Vector3.up * (pedestalHeight + columnHeight + capitalHeight/2), transform.rotation, transform);
        capitalInstance.transform.localScale = new Vector3(sideLength, capitalHeight, sideLength);
        capitalInstance.name = "Capital";
        _objects[2] = capitalInstance;

        BoxCollider box = GetComponent<BoxCollider>();
        box.size = new Vector3(sideLength, height, sideLength);
        box.center = new Vector3(0, height/2, 0);
    }

    void OnEnable()
    {
        Refresh();
    }

    void OnDisable()
    {
        for (int i=0;i<_objects.Length;i++)
        {
            if (_objects[i])
                DestroyImmediate(_objects[i]);
            _objects[i] = null;
        }
    }
}
