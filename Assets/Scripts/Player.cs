using System;
using UnityEngine;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    // Serialized fields to be set in the Unity Editor
    [SerializeField] private InputManager inputManager; // Reference to the InputManager script
    [SerializeField] private float speed; // Speed of the player
    [SerializeField] private float jumpHeight; // Height of the player's jump
    [SerializeField] private CinemachineCamera thirdPersonCam; // Reference to the third-person camera

    // Private fields
    float camRotationSpeed = 10f; // Speed at which the player rotates to face the movement direction
    private Rigidbody rb; // Reference to the Rigidbody component

    // Start is called before the first frame update
    void Start()
    {
        // Add listeners to the input manager's events
        inputManager.OnMove.AddListener(MovePlayer); // Adding MovePlayer listener to the OnMove event
        inputManager.OnJump.AddListener(PlayerJump); // Adding PlayerJump listener to the OnJump event

        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    // Method to move the player based on input direction
    private void MovePlayer(Vector3 direction)
    {
        // Get the forward direction of the camera, ignoring the y-axis
        Vector3 camForward = thirdPersonCam.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        // Get the right direction of the camera, ignoring the y-axis
        Vector3 camRight = thirdPersonCam.transform.right;
        camRight.y = 0f;
        camRight.Normalize();

        // Calculate the movement direction based on camera orientation
        Vector3 moveDirection = (camForward * direction.z + camRight * direction.x);

        // Rotate the player to face the movement direction
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * camRotationSpeed);

        // Set the player's velocity to move in the calculated direction
        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }

    // Method to make the player jump
    private void PlayerJump(Vector3 direction)
    {
        // Check if the player is grounded using a raycast
        if (Physics.Raycast(transform.position, -Vector3.up, 1.1f))
        {
            // Apply a force to the Rigidbody to make the player jump
            Vector3 jumpDirection = direction;
            rb.AddForce(jumpHeight * jumpDirection);
        }
    }
}
