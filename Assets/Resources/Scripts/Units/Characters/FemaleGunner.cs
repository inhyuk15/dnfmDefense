using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleGunner : Unit
{
    // Start is called before the first frame update
    void Start() { }

    public override void Attack() { }

    public override void MoveInDirection(Vector3 direction)
    {
        base.MoveInDirection(direction);

        // animation 관련 구현 필요
    }
}
