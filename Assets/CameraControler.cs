using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    private Vector2 currentMouseLook;
    private Vector2 appliedMouseDelta;

    void Update()
    {
        // Positional Movement
        float moveX = Input.GetAxis("Horizontal"); // A and D keys
        float moveZ = Input.GetAxis("Vertical");   // W and S keys

        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        // Mouse Look Rotation
        currentMouseLook.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        currentMouseLook.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -75f, 75f);

        appliedMouseDelta = Vector2.Lerp(appliedMouseDelta, currentMouseLook, 1f);
        transform.localRotation = Quaternion.AngleAxis(appliedMouseDelta.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(appliedMouseDelta.y, Vector3.right);
    }

}