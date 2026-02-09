using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    private MovementPlan movement;

    void Start()
    {
        movement = GetComponent<MovementPlan>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            movement.direction = MovementPlan.Direction.Up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            movement.direction = MovementPlan.Direction.Down;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            movement.direction = MovementPlan.Direction.Left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            movement.direction = MovementPlan.Direction.Right;
    }
}
