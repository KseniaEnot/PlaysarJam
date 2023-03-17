using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float gravity = 9.8f;
    public float playerSpeed = 1f;
    public float rotationSpeed = 1f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 move = new Vector3(0, 0, input.y);
        move.y -= gravity;

        move = this.transform.TransformDirection(move);
        controller.Move(move * playerSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up, input.x);
    }
}
