using Assets.Code.Entities;
using UnityEngine;
using UnityEngine.AI;

public class NpcRunFromDanger : MonoBehaviour, ReactToEnemy
{
    public float MinApproach;
    public float RunSafeDistance;

    private NpcRandomMovement randomMovement;
    private NavMeshAgent navAgent;
    private Vector3 runToPosition;

    void ReloadComponents()
    {
        if (randomMovement == null)
            randomMovement = GetComponent<NpcRandomMovement>();
        if (navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.randomMovement != null && Vector3.Distance(this.transform.position, runToPosition) < MinApproach)
        {
            this.randomMovement.enabled = true;
            this.enabled = false;
            this.randomMovement.SetNewNavPoint();
        }
    }

    public void React(Transform fromPos)
    {
        ReloadComponents();
        this.enabled = true;
        randomMovement.enabled = false;
        var transformEnemyPosition = this.transform.InverseTransformPoint(fromPos.position);
        runToPosition = this.transform.TransformPoint(-transformEnemyPosition * RunSafeDistance);

        if (navAgent != null)
        {
            navAgent.SetDestination(runToPosition);
        }
    }
}