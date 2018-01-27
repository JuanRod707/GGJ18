using UnityEngine;
using UnityEngine.AI;

public class MovementComponent : MonoBehaviour
{
    public float MoveSpeed;
    private NavMeshAgent meshAgent;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 movementOffset)
    {
        movementOffset = Vector3.ClampMagnitude(movementOffset, MoveSpeed);
        meshAgent.Move(movementOffset);
        RotateTowardsMovementDirection(movementOffset);
    }

    private void RotateTowardsMovementDirection(Vector3 movementOffset)
    {
        if (movementOffset != Vector3.zero)
            transform.rotation =
                Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementOffset.normalized), 0.2f);
    }
}