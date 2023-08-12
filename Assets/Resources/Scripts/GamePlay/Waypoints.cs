using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField]
    private float waypointSize = 1f;

    private void OnDrawGizmos()
    {
        foreach (Transform t in transform)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(t.position, waypointSize);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawLine(
                transform.GetChild(i % transform.childCount).position,
                transform.GetChild((i + 1) % transform.childCount).position
            );
        }
    }

    public Transform GetNextWayPoint(Transform currentWaypoint)
    {
        if (currentWaypoint == null)
        {
            return transform.GetChild(0);
        }

        int nextIdx = (currentWaypoint.GetSiblingIndex() + 1) % transform.childCount;
        return transform.GetChild(nextIdx);
    }
}
