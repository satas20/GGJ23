using UnityEngine;
public class CameraController : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public float smoothSpeed = 0.125f; // The speed of the camera movement
    public Vector2 offset; // The offset of the camera from the target
    public float threshold = 5f; // The threshold distance before the camera starts following
    private Vector3 lastTargetPosition;

    void Start()
    {
        // Save the initial position of the target
        lastTargetPosition = target.position;
    }

    void FixedUpdate()
    {
        // Calculate the distance between the current position of the target and its last position
        float distance = Vector3.Distance(target.position, lastTargetPosition);

        // Check if the distance is greater than the threshold
        if (distance > threshold)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = (Vector3)target.position + (Vector3)offset;
            desiredPosition.z = -10;

            // Use Lerp to smoothly move the camera to the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        // Save the current position of the target as its last position
        lastTargetPosition = target.position;
    }
}