using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class StickToTerrain : MonoBehaviour {

    float swingFr = 0;
    float swingAm = 0;

    public bool swing = false;

    // Use this for initialization
    void Start ()
    {
        if (swing) {
            swingFr = Random.value + 1.0f;
            swingAm = Random.value * 30.0f;
        }
        m_baseRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update ()
    {
        int layer = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, 100.0f), new Vector2(0.0f, -1.0f), 200.0f, layer);
        if (hit.collider != null)
        {
            transform.position = new Vector3(hit.point.x, hit.point.y, transform.position.z);
            transform.LookAt(transform.position + new Vector3(0.0f, 0.0f, 1.0f), hit.normal);
            transform.rotation = m_baseRotation * transform.rotation * Quaternion.Euler(0, 0, Mathf.Sin(Time.time * swingFr / 5.0f) * swingAm);
        }

    }

    Quaternion m_baseRotation;
}
