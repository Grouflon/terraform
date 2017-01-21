using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMvt : MonoBehaviour {

    public GameObject statesManager;

    Vector2 lastRunningPosition;
    // Vector2 lastTerraformPosition;

    void Start () {
		
	}

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + transform.localScale.y), Vector2.up);
        
        if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.terraform)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            if (hit.collider != null)
            {
                Vector2 pos = transform.position;
                pos.y += hit.distance + transform.localScale.y * 2;
                transform.position = pos;
            }
            transform.position = new Vector2(lastRunningPosition.x, Mathf.Min(lastRunningPosition.y,transform.position.y));
            // lastTerraformPosition = new Vector2(transform.position.x, transform.position.y);
        }

        if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.running)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(3.0f, 0));
            transform.position = new Vector2(transform.position.x%200, transform.position.y);
            lastRunningPosition = new Vector2(transform.position.x, transform.position.y);
        }

    }

}
