using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] float playerSpeed = 1f;

    private float initialPlayerSpeed;
    public CharacterController controller;
    private IInput inputController;

    public bool isInTrap = false;
    public bool isInDialog = false;

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
        bool diagonal = (input.x != 0) && (input.y != 0);
        if (move != Vector3.zero)
            transform.forward = move.normalized;
        move.y -= gravity;

        /* move = this.transform.TransformDirection(move);
         controller.Move(move * Speed * Time.deltaTime);

         transform.Rotate(Vector3.up, input.x * Rotation);*/
        var curSpeed = diagonal? Mathf.Sqrt(Speed) : Speed;
        controller.Move(move * curSpeed * Time.deltaTime);

    }

    public void SetInputType(IInput input) => inputController = input;

    public void ResetSpeed()
    {
        Speed = initialPlayerSpeed;
    }
}
