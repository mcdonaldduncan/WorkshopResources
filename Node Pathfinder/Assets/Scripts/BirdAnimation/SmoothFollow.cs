using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] Transform m_Target;
    [SerializeField] float m_MaxForce;
    [SerializeField] float m_MaxSpeed;
    [SerializeField] float m_Damping;

    Transform m_Transform;

    Vector3 m_Velocity;
    Vector3 m_Acceleration;

    private void Start()
    {
        m_Velocity = Vector3.zero;
        m_Transform = transform;
    }

    void Update()
    {
        //ApplySteering();
        DampFollow();
    }

    // Smooth following via damping
    void DampFollow()
    {
        m_Velocity = Vector3.ClampMagnitude(m_Velocity, m_MaxSpeed);

        var n1 = m_Velocity - (transform.position - m_Target.position) * Mathf.Pow(m_Damping, 2) * Time.deltaTime;
        var n2 = 1 + m_Damping * Time.deltaTime;
        m_Velocity = n1 / n2;

        transform.position += m_Velocity * Time.deltaTime;
    }

    // Smooth following via steering algorithm
    void ApplySteering()
    {
        m_Acceleration += CalculateSteering(m_Target.position);
        m_Velocity += m_Acceleration;
        m_Transform.position += m_Velocity * Time.deltaTime;
        m_Acceleration = Vector3.zero;
    }

    Vector3 CalculateSteering(Vector3 currentTarget)
    {
        Vector3 desired = currentTarget - m_Transform.position;
        desired = desired.normalized;
        desired *= m_MaxSpeed;
        Vector3 steer = desired - m_Velocity;
        steer = steer.normalized;
        steer *= m_MaxForce;
        return steer;
    }
}
