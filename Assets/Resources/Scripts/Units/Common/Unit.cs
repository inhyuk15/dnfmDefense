using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IUnit
{
    public string unitName;

    public float hp;
    public float mp;
    public float range;
    public float criticalChange;
    public float manaRegeneration;
    public float visionRange;

    public float damage;
    public float armor;
    public float attackSpeed;
    public float moveSpeed = 1;

    private Transform currentWaypoint;

    public virtual void Attack() { }

    public virtual void MoveInDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Vector3 nextDir = direction.normalized;
            transform.position += nextDir * moveSpeed * Time.deltaTime;
        }
    }

    public virtual void MoveToPosition(Vector3 nextPos)
    {
        Vector3 directionToTarget = (nextPos - transform.position).normalized;
        transform.position += directionToTarget * moveSpeed * Time.deltaTime;
    }
}
