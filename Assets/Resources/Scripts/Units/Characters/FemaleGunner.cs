using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleGunner : MonoBehaviour, IUnit
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Attack() {

    }

    public void Movement(Vector3 direction) {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private string unitName;

    private float hp;
    private float mp;
    private float range;
    private float criticalChange;
    private float manaRegeneration;
    private float visionRange;

    private float damage;
    private float armor;
    private float attackSpeed;
    private float moveSpeed;
}
