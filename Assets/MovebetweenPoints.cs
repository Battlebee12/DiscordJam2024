using UnityEngine;

public class MovebetweenPoints : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2.0f;

    private Vector3 target;

    void Start()
    {
        // Start moving towards pointB
        target = pointB;
    }

    void Update()
    {
        // Move the GameObject towards the target
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the GameObject has reached the target
        if (transform.position == target)
        {
            // Switch the target to the other point
            target = target == pointA ? pointB : pointA;
        }
    }
}

