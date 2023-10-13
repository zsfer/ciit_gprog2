using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerController m_Player;
    private CharacterController m_CC;

    public float MoveSpeed = 10;

    private Vector3 m_MoveVec;
    float _y;


    void Start()
    {
        m_Player = GetComponent<PlayerController>(); 
        m_CC = GetComponent<CharacterController>();
    }

    public void UpdateMovement()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        var fwd = Camera.main.transform.forward;
        var right = Camera.main.transform.right;
        fwd.y = right.y = 0;

        m_MoveVec = (fwd * m_Player.Input.InputVector.y + right * m_Player.Input.InputVector.x) * MoveSpeed;
        
        // FIXME janky jump
        if (m_CC.isGrounded)
        {
            m_MoveVec.y = 0;

            if (m_Player.Input.IsJump)
            {
                m_MoveVec.y = 20;
            }
        }

        print(m_CC.isGrounded);

        m_MoveVec.y += Physics.gravity.y;

        m_CC.Move(Time.deltaTime * m_MoveVec);

    }

    void HandleRotation()
    {
        var rotVec = m_MoveVec;
        rotVec.y = 0;

        if (rotVec.magnitude > 0)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotVec), 10 * Time.deltaTime);
    }
}
