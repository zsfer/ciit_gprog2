using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public bool IsJump { get; private set; }

    public Vector2 InputVector { get; private set; }
    private float _speedMult = 1;
    private bool _toggleWalk = false;

    public void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock)) _toggleWalk = !_toggleWalk;

        if (Input.GetKey(KeyCode.LeftShift)) _speedMult = 2;
        else if (Input.GetKey(KeyCode.LeftControl) || _toggleWalk) _speedMult = 0.5f;
        else _speedMult = 1;

        InputVector = (Vector3.right * Input.GetAxisRaw("Horizontal") + Vector3.up * Input.GetAxisRaw("Vertical")).normalized * _speedMult;

        IsJump = Input.GetKeyDown(KeyCode.Space);
    }
}
