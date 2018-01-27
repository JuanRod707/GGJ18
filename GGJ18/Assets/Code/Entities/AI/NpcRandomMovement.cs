using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcRandomMovement : MonoBehaviour
{
    public float MinApproach;

    private NavigationPoints navPoints;
    private Vector3 destination;
    private NavMeshAgent navAgent;

    void Start()
    {
        navPoints = GetComponentInParent<NPCManager>().NavPoints;
        navAgent = this.GetComponent<NavMeshAgent>();
        SetNewNavPoint();
    }

    void Update()
    {
        if (Vector3.Distance(this.transform.position, destination) < MinApproach)
        {
            SetNewNavPoint();
        }
    }

    public void SetNewNavPoint()
    {
        destination = navPoints.GetRandomPointPosition;
        navAgent.SetDestination(destination);
    }
}
