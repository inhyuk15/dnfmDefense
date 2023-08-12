using UnityEngine;

public interface IUnit
{
    public void Attack();
    public void MoveInDirection(Vector3 direction);
    public void MoveToPosition(Vector3 nextPos);
    // public void FlipHorizontal();
}
