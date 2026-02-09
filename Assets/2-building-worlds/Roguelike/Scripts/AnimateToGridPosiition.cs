using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TilePosition))]
public class AnimateToGridPosition : MonoBehaviour
{
    [SerializeField] private float timeTaken = 1;

    private bool moving;
    private Vector3Int lastPosition;
    private Coroutine coroutine;
    private TilePosition tilePosition;


    public bool IsMoving() { return this.moving; }

    void Start()
    {
        tilePosition = GetComponent<TilePosition>();
    }

    void Update()
    {
        if (lastPosition != tilePosition.position)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(Move(timeTaken));
            lastPosition = tilePosition.position;
        }
    }

    private IEnumerator Move(float duration)
    {
        moving = true;
        Vector3Int target = tilePosition.position;
        float start = Time.time;
        float t;
        do
        {
            t = (Time.time - start) / duration;
            transform.position = Vector3.Lerp(transform.position, tilePosition.tilemap.GetCellCenterWorld(target), t);
            yield return null;
        } while (t < 1);
        transform.position = tilePosition.tilemap.GetCellCenterWorld(target);
        moving = false;
    }

}
