using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // reference to the target to follow
    public float smoothSpeed = 0.125f; // smoothing speed for camera movement
    public Vector3 offset; // offset from the target position

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // calculate the desired camera position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // smoothly move the camera towards the desired position
        transform.position = desiredPosition; // update the camera position
    }
}
