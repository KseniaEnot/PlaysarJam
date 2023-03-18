using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float rotationSpeed = 1f;

    private float initialPlayerSpeed;
    private float initialRotationSpeed;
    private CharacterController controller;
    private IInput inputController;

    public float Speed
    {
        get
        {
            return playerSpeed;
        }

        set
        {
            playerSpeed = value;
        }
    }
    public float Rotation
    {
        get
        {
            return rotationSpeed;
        }

        set
        {
            rotationSpeed = value;
        }
    }

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputController = GetComponent<KeyboardInput>();

        initialPlayerSpeed = Speed;
        initialRotationSpeed = Rotation;
    }

    private void FixedUpdate()
    {
        var input = inputController.GetInput();
        Vector3 move = new Vector3(0, 0, input.y);
        move.y -= gravity;

        move = this.transform.TransformDirection(move);
        controller.Move(move * Speed * Time.deltaTime);

        transform.Rotate(Vector3.up, input.x * Rotation);
    }

    public void SetInputType(IInput input) => inputController = input;

    public void ResetSpeed()
    {
        Speed = initialPlayerSpeed;
        Rotation = initialRotationSpeed;
    }
}
