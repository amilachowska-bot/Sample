using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector3 = UnityEngine.Vector3;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 direction;

    public float jumpStrength = 500;

    public float moveSpeed = 300;
    public float rotateSpeed = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonDown("Jump"))
        // {
        //     Debug.Log("Jump!");
        //     rb.AddForce(Vector3.up * jumpStrength);
        // }

        // float horizontalDirection = Input.GetAxis("Horizontal");
        // rb.linearVelocity = new Vector3(horizontalDirection * moveSpeed, rb.linearVelocity.y, rb.linearVelocity.z);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, direction.x * rotateSpeed * Time.fixedDeltaTime);
        
        rb.linearVelocity = new Vector3(transform.right.x * direction.y * moveSpeed, rb.linearVelocity.y, transform.right.z * direction.y * moveSpeed);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        
        Debug.Log("Jump!");
        rb.AddForce(Vector3.up * jumpStrength);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Debug.Log("Move");
        direction = context.ReadValue<Vector2>();
        Debug.Log(direction);
    }
}
