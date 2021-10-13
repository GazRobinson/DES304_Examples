using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    [SerializeField]
    private CameraController m_Camera;
    private Vector2 inputDirection;
    private bool jump = false;
    void GetInput() {
        inputDirection = new Vector2( Input.GetAxis( "Horizontal" ), Input.GetAxis( "Vertical" ) );
        if (Input.GetButtonDown( "Jump" )) {
            jump = true;
        }

        m_Camera.Rotate(new Vector2(Input.GetAxis( "CameraHorizontal" ), Input.GetAxis( "CameraVertical" ) ) );
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        GetInput();
        Vector3 movement = ( inputDirection.x * m_Camera.GetRight() ) + ( inputDirection.y * m_Camera.GetForward() );
        movement.Normalize();
        velocity.x = movement.x;
        velocity.z = movement.z;
        velocity *= m_Stats.m_GroundSpeed;

        if(jump && m_IsGrounded) {
            velocity.y = 5.0f;
            jump = false;
        }
        transform.LookAt( transform.position + movement );
    }
}
