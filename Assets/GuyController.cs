using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyController : MonoBehaviour {

    public float speed = 5.0f;
    public float turnBackAngle = 45.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Debug.DrawLine(new Vector3(transform.position.x, 100.0f, 0.0f), new Vector3(transform.position.x, -100.0f, 0.0f), Color.yellow);

        Vector3 previousPosition = transform.position;
        transform.position = previousPosition + (transform.forward * speed * Time.fixedDeltaTime);

        int layer = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, 100.0f), new Vector2(0.0f, -1.0f), 200.0f, layer);

        if (hit.collider != null)
        {
            //Debug.DrawLine(hit.point, hit.point + hit.normal, Color.red);
            Vector3 forward;
            if (m_goingRight)
                forward = new Vector3(hit.normal.y, -hit.normal.x, 0.0f);
            else
                forward = new Vector3(-hit.normal.y, hit.normal.x, 0.0f);

            float angle = Mathf.Asin(forward.y) * Mathf.Rad2Deg;

            if (angle > turnBackAngle)
            {
                // TURN BACK
                m_goingRight = !m_goingRight;
                transform.position = previousPosition;
            }
            else
            {
                // GO ON
                Vector3 position = transform.position;
                position.x = hit.point.x;
                position.y = hit.point.y;
                transform.position = position;
                transform.LookAt(position + forward, hit.normal);
            }
        }
	}

    private bool m_goingRight = true;
}
