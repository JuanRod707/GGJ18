﻿using UnityEngine;
using UnityEngine.AI;

public class NpcRunFromDanger : MonoBehaviour
{

    public float MinApproach;

    private NpcRandomMovement randomMovement;
    private NavMeshAgent navAgent;
    private Vector3 runToPosition;

    void ReloadComponents()
    {
        if(randomMovement == null)
            randomMovement = GetComponent<NpcRandomMovement>();
        if(navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, runToPosition) < MinApproach)
        {
            randomMovement.enabled = true;
            this.enabled = false;
            randomMovement.SetNewNavPoint();
        }
    }
    public void StartRunning(Vector3 fromPos)
    {
        ReloadComponents();
        this.enabled = true;
        randomMovement.enabled = false;
        var transformEnemyPosition = this.transform.InverseTransformPoint(fromPos);
        runToPosition = this.transform.TransformPoint(-transformEnemyPosition);
        navAgent.SetDestination(runToPosition);
    }
}
