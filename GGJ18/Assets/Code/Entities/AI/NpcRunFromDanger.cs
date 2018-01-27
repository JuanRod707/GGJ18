using Assets.Code.Entities;
using UnityEngine;
using UnityEngine.AI;

public class NpcRunFromDanger : MonoBehaviour, ReactToMinion
{

    public float MinApproach;
    public float RunSafeDistance;

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
