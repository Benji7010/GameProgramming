using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Platformer : MonoBehaviour
{
    [SerializeField]
    public PlayerController control;

    private void Awake()
    {
        control = new PlayerController();
        control.Player1.Jump.performed += ctx => Jump();
        control.Player1.Left.performed += ctx => Left();
        control.Player1.Right.performed += ctx => Right();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(strafeSpeed, -gravSpeed, 0);
        Gravity();
    }

    const float gravTerminalVelocity = 0.5f;
    const float gravAcceleration = 0.001f;
    float gravSpeed = -0.1f;
    private void Gravity()
    {
        gravSpeed += gravAcceleration;
        gravSpeed = Mathf.Clamp(gravSpeed, maxJump, gravTerminalVelocity);
        //Debug.Log("GravSpeed: " + gravSpeed);
    }


    const float maxJump = -50f;
    private void Jump()
    {
        gravSpeed = -0.1f;
        Debug.Log("Jump!");
    }

    const float strafeAccel = 0.001f;
    const float strafeResist = 0.01f;
    float strafeSpeed;
    private void Left()
    {
        strafeSpeed -= strafeAccel;
    }

    private void Right()
    {
        strafeSpeed += strafeAccel;
    }

    private void OnEnable()
    {
        control.Enable();
    }

    private void OnDisable()
    {
        control.Disable();
    }
}
