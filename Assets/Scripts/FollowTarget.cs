using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;

    public float Damping = 5f;

    void Start()
    {
        if (Offset == Vector3.zero)
            Offset = transform.position;
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, Damping * Time.deltaTime);
    }
}
