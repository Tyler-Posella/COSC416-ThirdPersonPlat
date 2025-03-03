using UnityEngine;
using System;
using UnityEngine.Events;
using Unity.VisualScripting;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnMove = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnJump = new UnityEvent<Vector3>();

    void Update()
    {

        Vector3 input = Vector3.zero;
        Vector3 jumpInput = Vector3.zero;
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
        if (Input.GetKey(KeyCode.Space))
        {
            jumpInput += Vector3.up;
        }
        OnMove?.Invoke(input);
        OnJump?.Invoke(jumpInput);

        
    
    }
    void FixedUpdate()
    {

    }
}
