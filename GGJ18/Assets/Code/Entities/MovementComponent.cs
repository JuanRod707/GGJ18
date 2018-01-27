using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour
{
    public float MoveSpeed;
    private NavMeshAgent meshAgent;

    // Use this for initialization
    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 movementOffset)
    {
        meshAgent.Move(Vector3.ClampMagnitude(movementOffset, MoveSpeed));
    }
}