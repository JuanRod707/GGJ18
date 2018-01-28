using UnityEngine;
using UnityEngine.AI;

public class ChaseNpc : MonoBehaviour
{
    public float ForgetDistance;
    public Color LineColor;

    private NpcRandomMovement randomMovement;
    private NavMeshAgent navAgent;
    private Transform runToPosition;
    
    void ReloadComponents()
    {
        if(randomMovement == null)
            randomMovement = GetComponent<NpcRandomMovement>();
        if(navAgent == null)
            navAgent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (runToPosition != null)
        {
            if (Vector3.Distance(this.transform.position, runToPosition.position) > ForgetDistance)
            {
                StopChasing();
            }
            else
            {
                navAgent.SetDestination(runToPosition.position);
            }

            Debug.DrawLine(this.transform.position, runToPosition.position, LineColor);
        }
        else
        {
            ReloadComponents();
            StopChasing();
        }
    }

    void StopChasing()
    {
        randomMovement.enabled = true;
        this.enabled = false;
        randomMovement.SetNewNavPoint();
    }

    public void StartChasing(Transform chasePos)
    {
        runToPosition = chasePos;
        ReloadComponents();
        this.enabled = true;
        randomMovement.enabled = false;
        navAgent.SetDestination(chasePos.position);
    }
}
