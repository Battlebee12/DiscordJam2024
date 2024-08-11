using UnityEngine;

public class SlowRotateUI : MonoBehaviour
{
    // Rotation speed in degrees per second
    [SerializeField] private float rotationSpeed = 10f;

    private RectTransform rectTransform;

    private void Awake()
    {
        // Get the RectTransform component
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Calculate the rotation for this frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Apply the rotation to the RectTransform
        rectTransform.Rotate(Vector3.forward * rotationAmount);
    }
}

