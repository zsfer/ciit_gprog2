using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(PlayerLocomotion))]
public class PlayerController : MonoBehaviour
{
    public InputManager Input { get; private set; }
    public PlayerLocomotion Locomotion { get; private set; }

    public static PlayerController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Input = GetComponent<InputManager>();
        Locomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        Input.UpdateInput();
        Locomotion.UpdateMovement();
    }

    private void FixedUpdate()
    {
    }
}
