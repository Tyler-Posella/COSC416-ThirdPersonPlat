using TMPro; // Importing the TextMeshPro namespace for UI text manipulation
using UnityEngine; // Importing the UnityEngine namespace for Unity-specific classes and functions

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float score = 0; // Variable to store the player's score, initialized to 0
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component to display the score
    [SerializeField] private InputManager inputManager; // Reference to the InputManager component

    private CollectTrigger[] coins; // Array to store all CollectTrigger components in the scene

    void Start()
    {
        // Find all CollectTrigger components in the scene and store them in the coins array
        coins = FindObjectsByType<CollectTrigger>(FindObjectsSortMode.None);
        
        // Loop through each coin and add the IncrementScore method as a listener to the OnCoinCollect event
        foreach (CollectTrigger coin in coins)
        {
            coin.OnCoinCollect.AddListener(IncrementScore);
        }
    }

    // Method to increment the score and update the scoreText UI element
    private void IncrementScore()
    {
        score++; // Increment the score by 1

        // Update the scoreText UI element to display the new score
        scoreText.text = $"Score: {score}";
    }
}
