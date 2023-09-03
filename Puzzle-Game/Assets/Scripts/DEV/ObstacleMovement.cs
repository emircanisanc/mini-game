using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{
    [Tooltip("When reached to the end of waypoints it will turn back to the first waypoint")]
    [SerializeField] Transform[] waypoints;
    [SerializeField] float moveSpeed = 0.5f;
    int wpIndex = 0;

    private void Start()
    {
        if (waypoints.Length == 0)
            return;

        StartMovement();
    }

    private void StartMovement()
    {
        MoveToWaypoint(waypoints[wpIndex]);
    }

    private void MoveToNextWaypoint()
    {
        wpIndex = (wpIndex + 1) % waypoints.Length;
        MoveToWaypoint(waypoints[wpIndex]);
    }

    private void MoveToWaypoint(Transform waypoint)
    {
        Vector3 targetPos = waypoint.position;
        float delta = Vector3.Distance(transform.position, targetPos);
        transform.DOMove(targetPos, moveSpeed * delta).SetEase(Ease.Linear).OnComplete(MoveToNextWaypoint);
    }
}
