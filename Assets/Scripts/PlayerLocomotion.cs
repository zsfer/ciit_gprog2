using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    private PlayerController m_Player;
    private CharacterController m_CC;

    public float MoveSpeed = 10;

    private Vector3 m_MoveVec;


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
        m_MoveVec = Camera.main.transform.forward * m_Player.Input.InputVector.y + Camera.main.transform.right * m_Player.Input.InputVector.x;
        m_CC.SimpleMove(MoveSpeed * m_MoveVec);
    }

    void HandleRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(m_MoveVec), 10 * Time.deltaTime);
    }
}
