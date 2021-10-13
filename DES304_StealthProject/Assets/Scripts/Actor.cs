using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [System.Serializable] tells Unity that the class only contains 
// serializable variables and allows it to be displayed in the inspector!
[System.Serializable] 
public class ActorStats {
    public float m_GroundSpeed = 5.0f;
}

[RequireComponent(typeof(CharacterController))]
public class Actor : MonoBehaviour
{
    protected CharacterController m_CC;
    [SerializeField] //[SerializeField] allows a non-public variable to be displayed and edited in the Inspector
    protected ActorStats m_Stats;

    protected Vector3 velocity = Vector3.zero;
    protected bool m_IsGrounded = false;
    private void Awake() {
        m_CC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
        DoPhysics();

        CollisionFlags flags = m_CC.Move( velocity * Time.deltaTime );

        CollisionResponse( flags );
    }

    void DoPhysics() {
        if (!m_IsGrounded) {
            velocity += Physics.gravity * Time.deltaTime;
        }
    }

    void CollisionResponse(CollisionFlags flags ) {
        if((flags & CollisionFlags.Below) != 0) {
            velocity.y = 0.0f;
            m_IsGrounded = true;
        }
        if (( flags & CollisionFlags.Below ) == 0) {
            m_IsGrounded = false;
        }
    }

    protected virtual void OnAwake() { }
    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
}
