using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    [SerializeField]
    private Waypoints waypoints;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float distanceThreshold = 0.1f;

    [SerializeField]
    private Unit unit;

    private Transform currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUnit();
    }

    void MoveUnit()
    {
        if (Vector3.Distance(unit.transform.position, currentWaypoint.position) < distanceThreshold)
        {
            currentWaypoint = waypoints.GetNextWayPoint(currentWaypoint);
        }
        else
        {
            unit.MoveToPosition(currentWaypoint.position);
        }
    }

    void UpdateDirection() { }
}
