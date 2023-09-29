using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator m_Animator;

    private InputManager m_InputManager;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_InputManager = GetComponent<InputManager>();  
    }

    void Update()
    {
        m_Animator.SetFloat("Speed", m_InputManager.InputVector.normalized.sqrMagnitude, 0.05f, Time.deltaTime);
    }
}
