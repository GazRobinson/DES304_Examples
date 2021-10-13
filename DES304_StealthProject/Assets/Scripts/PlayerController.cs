using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Actor
{
    Vector2 inputDirection;
    bool jump = false;
    void GetInput() {
        inputDirection = new Vector2( Input.GetAxis( "Horizontal" ), Input.GetAxis( "Vertical" ) );
        if (Input.GetButtonDown( "Jump" )) {
            jump = true;
        }
    }

    // Update is called once per frame
    protected override void OnUpdate()
    {
        GetInput();

        velocity.x = inputDirection.x * m_Stats.m_GroundSpeed;
        velocity.z = inputDirection.y * m_Stats.m_GroundSpeed;

        if(jump && m_IsGrounded) {
            velocity.y = 5.0f;
            jump = false;
        }
    }
}
