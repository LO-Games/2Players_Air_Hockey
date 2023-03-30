using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    [SerializeField]
    private Rigidbody rb;
    private Vector2 movementInput;
    [SerializeField]
    private float velocity = 0.0f;
    public void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        System.Console.WriteLine(movementInput.magnitude);
        if (movementInput.magnitude > 0)
        {
            Vector3 movement = new Vector3(-movementInput.y, 0.0f, movementInput.x);
            rb.AddForce(movement * speed);
        }
    }
}
