using UnityEngine; // Import the UnityEngine namespace
using System; // Import the System namespace
using UnityEngine.Events; // Import the UnityEngine.Events namespace

public class CollectTrigger : MonoBehaviour
{
    // Event that gets triggered when a coin is collected
    public UnityEvent OnCoinCollect = new();

    // Boolean to check if the coin is collected
    public bool isCoinCollected = false;

    // Method called when another collider enters the trigger collider attached to the object where this script is attached
    private void OnTriggerEnter()
    {
        // Set the coin collected flag to true
        isCoinCollected = true;

        // Invoke the OnCoinCollect event
        OnCoinCollect.Invoke();

        // If the coin is collected, destroy the game object
        if (isCoinCollected)
        {
            Destroy(gameObject);
        }
    }
}
