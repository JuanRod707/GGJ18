using Assets.Code.Entities;
using UnityEngine;
using UnityEngine.AI;

public class NpcRunFromDanger : MonoBehaviour, ReactToEnemy
{
    public float MinApproach;
    public float RunSafeDistance;
    public float DistanceToReset;
    public Color LineColor;

    private NpcRandomMovement randomMovement;
    private NavMeshAgent navAgent;
    private Vector3 runToPosition;
    public Transform runFrom;

    void ReloadComponents()
    {
        if (randomMovement == null)
            randomMovement = GetComponent<NpcRandomMovement>();
        if (navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        ReloadComponents();
        if (Vector3.Distance(this.transform.position, runToPosition) < MinApproach)
        {
            ResumeFreeWalk();
        }

        if (runFrom != null)
        {
            if (Vector3.Distance(this.transform.position, runFrom.position) > DistanceToReset)
            {
                ResumeFreeWalk();
            }
        }
        else
        {
            ResumeFreeWalk();
        }

        Debug.DrawLine(this.transform.position, runToPosition, LineColor);
    }

    private void ResumeFreeWalk()
    {
        runFrom = null;
        this.randomMovement.enabled = true;
        this.enabled = false;
        this.randomMovement.SetNewNavPoint();
    }

    public void React(Transform fromPos)
    {
        ReloadComponents();
        runFrom = fromPos;
        this.enabled = true;
        randomMovement.enabled = false;
        var transformEnemyPosition = this.transform.InverseTransformPoint(fromPos.position);
        runToPosition = this.transform.TransformPoint(-transformEnemyPosition * RunSafeDistance);
        runToPosition.y = 0f;

        if (navAgent != null)
        {
            navAgent.SetDestination(runToPosition);
        }
    }
}