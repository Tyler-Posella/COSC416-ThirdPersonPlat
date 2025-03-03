using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    private Rigidbody rb;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer); //Adding MovePlayer listener to the OnMove event.
        inputManager.OnJump.AddListener(PlayerJump);
        rb = GetComponent<Rigidbody>();


    }

    private void MovePlayer(Vector3 direction)
    {
        Vector3 moveDirection = new(direction.x, 0f, direction.z);
        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);

    }
    private void PlayerJump(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, -Vector3.up, 1.1f))
        {
            Vector3 jumpDirection = direction;
            rb.AddForce(jumpHeight * jumpDirection);
            Debug.Log("true");
        }
    }
}
