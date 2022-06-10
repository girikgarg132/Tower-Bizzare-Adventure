using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFactory : MonoBehaviour
{
    [SerializeField] int cannonLimit = 5;
    [SerializeField] Cannon cannonPrefab;
    [SerializeField] Transform cannonParentTransform;

    private Queue<Cannon> cannonQueue = new Queue<Cannon>();

    public void AddCannon(Waypoint baseWaypoint)
    {
        if (cannonQueue.Count < cannonLimit)
        {
            InstantiateNewCannons(baseWaypoint);
        }
        else
        {
            MoveExistingCannon(baseWaypoint);
        }
    }

    private void InstantiateNewCannons(Waypoint oldBaseWaypoint)
    {
        Cannon newCannon = Instantiate(cannonPrefab, oldBaseWaypoint.transform.position, Quaternion.identity, cannonParentTransform);
        newCannon.baseWaypoint = oldBaseWaypoint;
        cannonQueue.Enqueue(newCannon);
        oldBaseWaypoint.isPlaceable = false;
    }

    private void MoveExistingCannon(Waypoint newBaseWaypoint)
    {
        Cannon oldCannon = cannonQueue.Dequeue();
        oldCannon.transform.position = newBaseWaypoint.transform.position;
        oldCannon.baseWaypoint.isPlaceable = true;
        newBaseWaypoint.isPlaceable = false;
        oldCannon.baseWaypoint = newBaseWaypoint;
        cannonQueue.Enqueue(oldCannon);
    }
}
