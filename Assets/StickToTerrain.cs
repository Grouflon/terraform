using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StickToTerrain : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        m_baseRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        int layer = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, 100.0f), new Vector2(0.0f, -1.0f), 200.0f, layer);
        if (hit.collider != null)
        {
            transform.position = hit.point;
            Vector3 forward = new Vector3(hit.normal.y, -hit.normal.x, 0.0f); ;
            transform.LookAt(transform.position + forward, hit.normal);

            transform.rotation = m_baseRotation * transform.rotation;
        }
    }

    Quaternion m_baseRotation;
}
