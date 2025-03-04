using UnityEngine;
using System;
using UnityEngine.Events;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour {
    // Event triggered when movement input is detected.
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();

    // Event triggered when jump input is detected.
    public UnityEvent<Vector3> OnJump = new UnityEvent<Vector3>();

    // Event triggered when double jump input is detected.
    public UnityEvent<Vector3> doDoubleJump = new UnityEvent<Vector3>();

    void Update()
    {
        // Initialize input vectors
        Vector3 input = Vector3.zero;
        Vector3 jumpInput = Vector3.zero;

        // Check for movement input
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector3.back;
        }
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector3.forward;
        }

        // Check for jump input
        if (Input.GetKey(KeyCode.Space))
        {
            jumpInput += Vector3.up;
        }

        // Invoke movement and jump events
        OnMove?.Invoke(input);
        OnJump?.Invoke(jumpInput);
    }
}
