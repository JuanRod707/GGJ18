using UnityEngine;
using UnityEngine.AI;

public class AnimatorOrientatorPlayer : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent navigator;
    private SpriteRenderer sprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void UpdateDisplay(Vector2 input)
    { 
        // Facedir is: 0 = North, 1 = Horizontal, 2 = South
        int faceDir = 0;

        if (Mathf.Abs(input.y) > Mathf.Abs(input.x))
        {
            if (input.y > 0)
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
            if (input.x > 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }

        animator.SetInteger("FaceDir", faceDir);
    }
}