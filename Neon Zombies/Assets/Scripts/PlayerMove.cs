using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] float playerSpeed = 1f;

    private float initialPlayerSpeed;
    private CharacterController controller;
    private IInput inputController;

    public bool isInTrap = false;

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

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputController = KeyboardInput.getInstance();
        initialPlayerSpeed = Speed;
    }

    private void FixedUpdate()
    {
        if (isInTrap) return;

        var input = inputController.GetInput();
        Vector3 move = new Vector3(input.x, 0, input.y);
        if (move != Vector3.zero)
            transform.forward = move.normalized;
        move.y -= gravity;

        /* move = this.transform.TransformDirection(move);
         controller.Move(move * Speed * Time.deltaTime);

         transform.Rotate(Vector3.up, input.x * Rotation);*/
        controller.Move(move * Speed * Time.deltaTime);

    }

    public void SetInputType(IInput input) => inputController = input;

    public void ResetSpeed()
    {
        Speed = initialPlayerSpeed;
    }
}
