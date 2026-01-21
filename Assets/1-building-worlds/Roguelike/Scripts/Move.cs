using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MovementPlan))]
[RequireComponent(typeof(TilePosition))]
public class Move : MonoBehaviour
{
    [SerializeField] private float movementTime = 1f;

    private MovementPlan movement;
    private TilePosition tilePosition;
    private bool startedMove;
    private bool waiting;

    void Start()
    {
        movement = GetComponent<MovementPlan>();
        tilePosition = GetComponent<TilePosition>();
    }

    void Update()
    {
        if (!waiting)
        {
            if (movement.direction == MovementPlan.Direction.Up)
                AttemptMoveTo(tilePosition.position + Vector3Int.up);
            if (movement.direction == MovementPlan.Direction.Down)
                AttemptMoveTo(tilePosition.position + Vector3Int.down);
            if (movement.direction == MovementPlan.Direction.Left)
                AttemptMoveTo(tilePosition.position + Vector3Int.left);
            if (movement.direction == MovementPlan.Direction.Right)
                AttemptMoveTo(tilePosition.position + Vector3Int.right);
        }
    }

    void LateUpdate()
    {
        if (startedMove)
            movement.direction = MovementPlan.Direction.None;
        startedMove = false;
    }

    private bool AttemptMoveTo(Vector3Int target)
    {
        startedMove = true;
        if (tilePosition.tilemap.GetTile(target) == null)
        {
            tilePosition.position = target;
            StartCoroutine(Wait());
            return true;
        }
        return false;
    }

    private IEnumerator Wait()
    {
        waiting = true;
        yield return new WaitForSeconds(movementTime);
        waiting = false;
    }
}
