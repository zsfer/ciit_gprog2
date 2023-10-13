using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float MouseSensitivity;

    Vector3 _mouseRot;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        _mouseRot += Vector3.up * Input.GetAxisRaw("Mouse X") + Vector3.right * -Input.GetAxisRaw("Mouse Y");

        transform.rotation = Quaternion.Euler(_mouseRot * MouseSensitivity);
    }
}
