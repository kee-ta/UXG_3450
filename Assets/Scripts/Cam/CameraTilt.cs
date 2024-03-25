using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    public float maxTiltAngle = 10.0f;
    public float tiltSpeed = 5.0f;
    public string horizontalAxis = "Horizontal";

    private float currentTiltAngle = 0.0f;

    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw(horizontalAxis);

        if (horizontalMovement != 0f)
        {
            float targetTiltAngle = -horizontalMovement * maxTiltAngle;
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, targetTiltAngle, Time.deltaTime * tiltSpeed);
        }
        else
        {
            currentTiltAngle = Mathf.Lerp(currentTiltAngle, 0f, Time.deltaTime * tiltSpeed);
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, currentTiltAngle);
    }
}
