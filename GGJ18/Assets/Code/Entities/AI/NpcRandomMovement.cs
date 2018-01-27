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

        Vector3 enemyPos = Vector3.zero;
        var transformedEnemyPos = this.transform.InverseTransformPoint(enemyPos);
        var resultInvertedPosition = this.transform.TransformPoint(-transformedEnemyPos);

    }

    public void SetNewNavPoint()
    {
        destination = navPoints.GetRandomPointPosition;
        navAgent.SetDestination(destination);
    }

    private void OnTriggerEnter(Collider other)
    {

    }
}
