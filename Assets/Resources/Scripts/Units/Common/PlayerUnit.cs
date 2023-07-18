using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour, IUnit
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

    public virtual void Attack() { }

    public virtual void Movement(Vector3 direction) { }
}
