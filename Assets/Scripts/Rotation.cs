using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float RotationSpeed = 10;
    float x, y, z;

    Quaternion currRot;
    Vector3 currEuler;
    void Start()
    {

    }

    private void OnGUI()
    {
        GUIStyle style = new()
        {
            fontSize = 16
        };

        GUI.Label(new Rect(10, 0, 0, 0), $"velocity: [{x}, {y}, {z}]", style);
        GUI.Label(new Rect(10, 32, 0, 0), $"current euler: {currEuler}", style);
        GUI.Label(new Rect(10, 48, 0, 0), $"world euler: {transform.eulerAngles}", style);
    }

    void Update()
    {
    }

    void RotateInput()
    {
        if (Input.GetKeyDown(KeyCode.X)) x = 1 - x;
        if (Input.GetKeyDown(KeyCode.Y)) y = 1 - y;
        if (Input.GetKeyDown(KeyCode.Z)) z = 1 - z;

        currEuler += RotationSpeed * Time.deltaTime * new Vector3(x, y, z);
        currRot.eulerAngles = currEuler;

        transform.rotation = currRot;
    }


}
