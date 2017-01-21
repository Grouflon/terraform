using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMvt2 : MonoBehaviour
{

    Vector2 lastRunningPosition;

    public WheelJoint2D frontWheel;
    public WheelJoint2D backWheel;

    public float speed = 200.0f;
    public float maxTorque = 10000;

    void Start()
    {
        m_stateManager = FindObjectOfType<StatesManager>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_previousState = m_stateManager.state;
    }

    void Update()
    {
        float heightLookup = 100;
        int layer = LayerMask.GetMask("Terrain");

        if (m_stateManager.state == StatesManager.GameStates.terraform)
        {
            if (m_previousState != m_stateManager.state)
            {
                m_previousVelocity = m_rigidbody.velocity;
                m_previousAngularVelocity = m_rigidbody.angularVelocity;
            }

            m_rigidbody.velocity = new Vector2(0, 0);
            m_rigidbody.angularVelocity = 0.0f;
            _SyncWheels();

            if (transform.position.y > lastRunningPosition.y) transform.position = new Vector2(lastRunningPosition.x, lastRunningPosition.y);
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + heightLookup), Vector2.down, heightLookup, layer);
            if (hit.collider != null)
            {
                if (hit.point.y > transform.position.y)
                {
                    transform.position = new Vector2(transform.position.x, hit.point.y + 0.5f);
                }
            }
        }

        if (m_stateManager.state == StatesManager.GameStates.running)
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(7.0f, 0));
            if (m_previousState != m_stateManager.state)
            {
                m_rigidbody.velocity = m_previousVelocity;
                m_rigidbody.angularVelocity = m_previousAngularVelocity;
            }

            m_frontMotor.motorSpeed = -speed;
            m_frontMotor.maxMotorTorque = maxTorque;
            frontWheel.motor = m_frontMotor;

            /*m_backMotor.motorSpeed = -speed * 0.5f;
            m_backMotor.maxMotorTorque = maxTorque;
            backWheel.motor = m_backMotor;*/

            float screenStart = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x - 1.0f;
            float screenEnd = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x + 1.0f;

            if (transform.position.x > screenEnd)
            {
                transform.position = new Vector2(transform.position.x - (screenEnd - screenStart), transform.position.y);

                RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + heightLookup), Vector2.down, heightLookup, layer);
                if (hit.collider != null)
                {
                    if (hit.point.y > transform.position.y)
                    {
                        transform.position = new Vector2(transform.position.x, hit.point.y + 0.5f);
                    }
                }

                _SyncWheels();
            }
            lastRunningPosition = new Vector2(transform.position.x, transform.position.y);
        }

        m_previousState = m_stateManager.state;
    }

    void _SyncWheels()
    {
        frontWheel.connectedBody.transform.position = transform.position + new Vector3(frontWheel.anchor.x, frontWheel.anchor.y, 0.0f);
        backWheel.connectedBody.transform.position = transform.position + new Vector3(backWheel.anchor.x, backWheel.anchor.y, 0.0f);
    }

    JointMotor2D m_frontMotor;
    JointMotor2D m_backMotor;

    Vector2 m_previousVelocity;
    float m_previousAngularVelocity;
    StatesManager.GameStates m_previousState;

    StatesManager m_stateManager;
    Rigidbody2D m_rigidbody;
}
