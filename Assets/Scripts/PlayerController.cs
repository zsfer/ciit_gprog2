using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(PlayerLocomotion))]
public class PlayerController : MonoBehaviour
{
    public InputManager Input { get; private set; }
    public PlayerLocomotion Locomotion { get; private set; }

    void Start()
    {
        Input = GetComponent<InputManager>();
        Locomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        Input.UpdateInput();
    }

    private void FixedUpdate()
    {
        Locomotion.UpdateMovement();
    }
}
