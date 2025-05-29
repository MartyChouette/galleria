using UnityEngine;

public class ThirdPersonOrbitCamera : MonoBehaviour
{
    public Transform target; // Player target
    public Vector2 rotationSpeed = new Vector2(120f, 80f);
    public Vector2 pitchClamp = new Vector2(-30f, 60f);
    public float distance = 4f;
    public float height = 1.5f;

    [Header("Zoom Settings")]
    public float minDistance = 2f;
    public float maxDistance = 8f;
    public float zoomSpeed = 2f;

    private float yaw;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    void LateUpdate()
    {
        HandleZoom();
        HandleRotation();
        UpdatePosition();
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        distance -= scroll * zoomSpeed;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
    }

    void HandleRotation()
    {
        yaw += Input.GetAxis("Mouse X") * rotationSpeed.x * Time.deltaTime;
        pitch -= Input.GetAxis("Mouse Y") * rotationSpeed.y * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, pitchClamp.x, pitchClamp.y);
    }

    void UpdatePosition()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = rotation * new Vector3(0f, 0f, -distance);
        Vector3 targetPos = target.position + new Vector3(0f, height, 0f);

        transform.position = targetPos + offset;
        transform.LookAt(targetPos);
    }
}