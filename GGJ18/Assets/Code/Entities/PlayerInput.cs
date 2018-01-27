using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    private NavMeshAgent meshAgent;
    public float MoveSpeed;

    public enum InputTypeEnum
    {
        Keyboard,
        Joystick
    }

    public InputTypeEnum InputType;

    void Start()
    {
        meshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
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
        if (offset != Vector3.zero)
        {
            offset = Vector3.ClampMagnitude(offset, MoveSpeed);
            meshAgent.Move(offset);
        }
    }

    private Vector3 DetermineKeyboardOffset()
    {
        Vector3 offset = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            offset += Vector3.left * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            offset += Vector3.back * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            offset += Vector3.right * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            offset += Vector3.forward * MoveSpeed;
        }
        return offset;
    }

    private Vector3 DetermineJoystickOffset()
    {
        Vector3 offset = Vector3.zero;
        var verticalAxisValue = Input.GetAxis("Vertical");
        var horizontalAxisValue = Input.GetAxis("Horizontal");
        offset = new Vector3(horizontalAxisValue, 0.0f, verticalAxisValue);
        return offset;
    }
}