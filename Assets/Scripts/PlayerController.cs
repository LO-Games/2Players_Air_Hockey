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

    private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.tag == "Player")
    {
        // Get the Rigidbody of the object that hit the player
    Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();
    if (otherRb != null)
    {
        // Calculate the direction of the hit
        Vector3 hitDirection = collision.contacts[0].point - transform.position;
        hitDirection = hitDirection.normalized;

        // Apply an equal and opposite force to the object that hit the player
        otherRb.AddForce(hitDirection * collision.impulse.magnitude, ForceMode.Impulse);
        otherRb.velocity = Vector3.zero;
        otherRb.angularVelocity = Vector3.zero;

        // Stop the player from moving
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
    }
}
}
}
