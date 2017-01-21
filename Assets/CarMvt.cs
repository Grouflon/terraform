using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMvt : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, 0));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y+transform.localScale.y), Vector2.up);
        if (hit.collider!=null) {
            Vector2 pos = transform.position;
            pos.y += hit.distance + transform.localScale.y*2;
            transform.position = pos;
        }
	}
}
