using UnityEngine;
using UnityEngine.AI;

public class AnimatorOrientator : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navigator;
    private SpriteRenderer sprite;

    void Start()
    {
        navigator = GetComponentInParent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var moveDir = navigator.velocity;

        // Facedir is: 0 = North, 1 = Horizontal, 2 = South
        int faceDir = 0;

        if (Mathf.Abs(moveDir.z) > Mathf.Abs(moveDir.x))
        {
            if (moveDir.z > 0)
            {
                faceDir = 0;
            }
            else
            {
                faceDir = 2;
            }
        }
        else
        {
            faceDir = 1;
            if (moveDir.x > 0)
            {
                sprite.flipX = false;
            }
            else
            {
                sprite.flipX = true;
            }
        }

        animator.SetInteger("FaceDir", faceDir);
    }
}