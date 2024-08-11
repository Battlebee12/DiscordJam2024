using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset distance between the camera and the player
    public float smoothSpeed = 0.125f; // Smoothness of the camera movement

    void Start()
    {
        // If the player Transform is not set in the Inspector, try to find it automatically
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("PLAYER").transform;
        }
    }

    void FixedUpdate()
    {
        // Desired position of the camera, with the same z position to prevent camera rotation in 2D
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;
    }
}
