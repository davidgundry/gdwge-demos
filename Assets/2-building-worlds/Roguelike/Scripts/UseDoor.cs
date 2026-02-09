using UnityEngine;

[RequireComponent(typeof(MovementPlan))]
[RequireComponent(typeof(TilePosition))]
public class UseDoor : MonoBehaviour
{
    private MovementPlan movement;
    private TilePosition tilePosition;
    private bool acted;

    void Start()
    {
        movement = GetComponent<MovementPlan>();
        tilePosition = GetComponent<TilePosition>();
    }

    void LateUpdate()
    {
        if (movement.direction == MovementPlan.Direction.Up)
            AttemptUseDoor(tilePosition.position + Vector3Int.up);
        else if (movement.direction == MovementPlan.Direction.Down)
            AttemptUseDoor(tilePosition.position + Vector3Int.down);
        else if (movement.direction == MovementPlan.Direction.Left)
            AttemptUseDoor(tilePosition.position + Vector3Int.left);
        else if (movement.direction == MovementPlan.Direction.Right)
            AttemptUseDoor(tilePosition.position + Vector3Int.right);

        if (acted)
            movement.direction = MovementPlan.Direction.None;
        acted = false;
    }


    private bool AttemptUseDoor(Vector3Int target)
    {
        if (tilePosition.tilemap.GetTile(target) != null)
        {
            tilePosition.tilemap.SetTile(target, null);
            acted = true;
            return true;
        }
        return false;
    }
}
