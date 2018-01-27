using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInputHandler : MonoBehaviour
{
    private AttackComponent attackComponent;
    private NavMeshAgent meshAgent;
    private MovementComponent movementComponent;
    private PlayerIdComponent playerIdComponent;
    private const string verticalAxisTag = "Vertical_P";
    private const string horizontalAxisTag = "Horizontal_P";
    private const string attackButtonTag = "Attack_P";

    public enum InputTypeEnum
    {
        Keyboard,
        Joystick
    }

    public InputTypeEnum InputType;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
        attackComponent = GetComponent<AttackComponent>();
        movementComponent = GetComponent<MovementComponent>();
        playerIdComponent = GetComponent<PlayerIdComponent>();
        if (playerIdComponent == null)
        {
            throw new ArgumentNullException("PlayerIdComponent is not assigned to player");
        }
    }

    void Update()
    {
        HandleMovementInput();
        HandleAttackInput();
    }

    private void HandleMovementInput()
    {
        if (movementComponent == null)
        {
            Debug.LogError("Movement component is not attached to game object.");
        }
        else
        {
            Vector3 offset;
            switch (InputType)
            {
                case InputTypeEnum.Keyboard:
                    offset = DetermineKeyboardOffset();
                    break;
                case InputTypeEnum.Joystick:
                    offset = DetermineJoystickOffset();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            movementComponent.Move(offset);
        }
    }

    private Vector3 DetermineKeyboardOffset()
    {
        Vector3 offset = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            offset += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            offset += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            offset += Vector3.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            offset += Vector3.forward;
        }
        return offset;
    }

    private Vector3 DetermineJoystickOffset()
    {
        Vector3 offset = Vector3.zero;
        var verticalAxisValue = Input.GetAxis(verticalAxisTag + playerIdComponent.PlayerId);
        var horizontalAxisValue = Input.GetAxis(horizontalAxisTag + playerIdComponent.PlayerId);
        offset = new Vector3(horizontalAxisValue, 0.0f, verticalAxisValue);
        return offset;
    }

    private void HandleAttackInput()
    {
        if (movementComponent == null)
        {
            Debug.LogError("Movement component is not attached to game object.");
        }
        if (Input.GetButtonDown(attackButtonTag + playerIdComponent.PlayerId))
        {
            attackComponent.AttemptAttack();
        }
    }
}