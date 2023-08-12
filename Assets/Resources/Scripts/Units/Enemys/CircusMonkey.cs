using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircusMonkey : Unit
{
    void Start() { }

    public override void MoveInDirection(Vector3 direction)
    {
        base.MoveInDirection(direction);

        // animation 관련 구현 필요
    }

    public override void MoveToPosition(Vector3 nextPos)
    {
        base.MoveToPosition(nextPos);
    }
}
