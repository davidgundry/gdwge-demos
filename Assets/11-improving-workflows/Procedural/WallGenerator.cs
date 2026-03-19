using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[SelectionBase]
[ExecuteInEditMode]
public class WallGenerator : MonoBehaviour
{
    [Serializable] public struct WallDecor
    {
        public GameObject prefab;
        public bool scaleY;
        public Vector3 offset;
    }

    [HideInInspector] public Vector3 end;
    [Range(1f, 10f)] public float height = 1.0f;
    [Range(0.1f, 1f)] public float width = 1.0f;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private WallDecor[] decor;
    public int objectCount = 0;

    private GameObject[] _objects = new GameObject[10];
    private GameObject _wall;

    public float Length { get { return hypotenuse(end.x - transform.position.x, end.z - transform.position.z); } }
    public Quaternion Angle { get { return Quaternion.LookRotation(end - transform.position, Vector3.up); } }
    private float hypotenuse(float a, float b) { return Mathf.Sqrt(a*a + b*b); }

    void Reset()
    {
        if (wallPrefab == null)
        {
            AsyncOperationHandle<GameObject> opHandle = Addressables.LoadAssetAsync<GameObject>("Procedural/ProBuilderCube.prefab");
            opHandle.WaitForCompletion();
            wallPrefab = opHandle.Result;
        }
        Refresh();
        end = transform.position + new Vector3(1, 0, 0);
    }

    public void Refresh()
    {
        RecreateMesh();
        RecreateObjects();
    }

    [ContextMenu("Recreate Objects")]
    public void RecreateObjects()
    {        
        for (int i=0;i<_objects.Length;i++)
        {
            if (_objects[i])
                DestroyImmediate(_objects[i]);
            _objects[i] = null;
        }
        _objects= new GameObject[objectCount];
        
        if (decor != null && decor.Length > 0)
        {
            Quaternion angle = Angle;
            Quaternion outwards = angle *= Quaternion.Euler(Vector3.up * 90);
            for (int i=0;i<_objects.Length;i++)
            {
                WallDecor decorItem = decor[i % decor.Length];

                Vector3 position = Vector3.Lerp(transform.position, end, ((float) i+1)/(_objects.Length+1));
                position += outwards * decorItem.offset;

                GameObject newObj = Instantiate(decorItem.prefab, position, angle, transform);
                _objects[i] = newObj;
                _objects[i].name = decorItem.prefab.name;
                
                if (decorItem.scaleY)
                    newObj.transform.localScale = new Vector3(1, height, 1);
            }
        }
    }

    [ContextMenu("Recreate Mesh")]
    public void RecreateMesh() {

        if (_wall != null)
        {
            DestroyImmediate(_wall);
            _wall = null;
        }
        _wall = Instantiate(wallPrefab, (end + transform.position)/2f + new Vector3(0, height/2f, 0), Angle);
        _wall.transform.parent = transform;
        _wall.transform.localScale = new Vector3(width, height, Length);
        _wall.name = "Wall";
        transform.localScale = new Vector3(1,1,1);
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
        if (_wall)
        {
            DestroyImmediate(_wall);
            _wall = null;
        }
    }
}
