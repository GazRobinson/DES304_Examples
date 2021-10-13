using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform m_Target;

    private float yaw = 0.0f, pitch = 0.0f;
    private float m_Distance = 5.0f;

    public Vector2 m_RotationSpeed = Vector2.one;

    public void Rotate(Vector2 direction ) {
        yaw += direction.x * Time.deltaTime * m_RotationSpeed.x;
        pitch += direction.y * Time.deltaTime * m_RotationSpeed.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_Target) {
            transform.position = m_Target.position;
            transform.rotation = Quaternion.AngleAxis( yaw, Vector3.up ) * Quaternion.AngleAxis( pitch, Vector3.right );
            transform.position -= transform.forward * m_Distance;
        }
    }

    public Vector3 GetForward() {
        Vector3 fwd = transform.forward;
        fwd.y = 0.0f;
        return fwd.normalized;
    }
    public Vector3 GetRight() {
        Vector3 right = transform.right;
        right.y = 0.0f;
        return right.normalized;
    }
}
