using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMvt : MonoBehaviour {

    [HideInInspector]
    public StatesManager statesManager;

    public float jumpSpeedThreshold = 0.01f;
    public float jumpForce = 10.0f;

    public float motorSpeedThreshold = 1.0f;
    public float motorForce = 10.0f;

    Vector2 lastRunningPosition;

    void Start () {
        statesManager = FindObjectOfType<StatesManager>();
        m_collider = GetComponent<Collider2D>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float heightLookup = 100;

        // WRAPPING
        float screenStart = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x - 1.0f;
        float screenEnd = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x + 1.0f;
        if (transform.position.x > screenEnd)
        {
            transform.position = new Vector2(transform.position.x - (screenEnd - screenStart), transform.position.y);
        }
        else if (transform.position.x < screenStart)
        {
            transform.position = new Vector2(transform.position.x + (screenEnd - screenStart), transform.position.y);
        }

        /*if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.terraform)
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            if (transform.position.y > lastRunningPosition.y) transform.position = new Vector2(lastRunningPosition.x, lastRunningPosition.y);
            int layer = LayerMask.GetMask("Terrain");
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + heightLookup), Vector2.down, heightLookup * 2.0f, layer);
            if (hit.collider != null) if (hit.point.y > transform.position.y) transform.position = new Vector2(transform.position.x, hit.point.y+transform.localScale.y/2);
        }*/

        //if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.running)
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(15.0f, 0));
            //transform.position = new Vector2(((transform.position.x+100)%200)-100, transform.position.y);

            lastRunningPosition = new Vector2(transform.position.x, transform.position.y);
            int layer = LayerMask.GetMask("Terrain");
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + heightLookup), Vector2.down, heightLookup * 2.0f, layer);
            if (hit.collider != null)
            {
                if (hit.point.y > transform.position.y) transform.position = new Vector2(transform.position.x, hit.point.y + transform.localScale.y / 2);
            }

            if (m_touchingGround)
            {
                if (m_rigidbody.velocity.magnitude < jumpSpeedThreshold)
                {
                    m_rigidbody.AddForce(m_groundNormal * jumpForce, ForceMode2D.Impulse);
                }

                if (Mathf.Abs(m_rigidbody.velocity.x) > motorSpeedThreshold)
                {
                    m_rigidbody.AddTorque(Mathf.Sign(-m_rigidbody.velocity.x) * motorForce, ForceMode2D.Force);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            m_touchingGround = true;
            m_groundNormal = col.contacts[0].normal;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            m_groundNormal = col.contacts[0].normal;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.gameObject.layer == LayerMask.NameToLayer("Terrain"))
        {
            m_touchingGround = false;
        }
    }

    bool m_touchingGround = false;
    Vector2 m_groundNormal;
    Rigidbody2D m_rigidbody;
    Collider2D m_collider;
}
