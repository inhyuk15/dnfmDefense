using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleGunner : PlayerUnit
{
    // Start is called before the first frame update
    void Start() { }

    public override void Attack() { }

    public override void Movement(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            // Debug.Log(direction);
            Vector3 nextDir = direction.normalized;
            transform.position += nextDir * moveSpeed * Time.deltaTime;
        }
    }
}
