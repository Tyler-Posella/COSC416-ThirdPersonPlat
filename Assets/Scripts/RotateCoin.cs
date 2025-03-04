using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // Speed at which the coin will spin
    [SerializeField] private float coinSpinSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be placed here
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the coin around its local Z axis at the specified speed
        transform.Rotate(0, 0, coinSpinSpeed, Space.Self);
    }
}
