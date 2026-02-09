using UnityEngine;


public class MovementPlan : MonoBehaviour
{
    public enum Direction {
        None,
        Up,
        Down,
        Left, 
        Right
    }

    public Direction direction;
}
