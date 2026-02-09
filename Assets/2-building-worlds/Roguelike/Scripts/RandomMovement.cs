using UnityEngine;


public class RandomMovement : MonoBehaviour
{
    private MovementPlan movement;
    
    void Start()
    {
        movement = GetComponent<MovementPlan>();
    }

    void Update()
    {
        if (movement.direction == MovementPlan.Direction.None)
        {
            int dir = Random.Range(0, 4);
            if (dir == 0)
                movement.direction = MovementPlan.Direction.Up;
            else if (dir == 1)
                movement.direction = MovementPlan.Direction.Down;
            else if (dir == 2)
                movement.direction = MovementPlan.Direction.Left;
            else if (dir == 3)
                movement.direction = MovementPlan.Direction.Right;
        }
    }
}
