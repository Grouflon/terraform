using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMvt : MonoBehaviour {

    [HideInInspector]
    public StatesManager statesManager;

    Vector2 lastRunningPosition;

    void Start () {
        statesManager = FindObjectOfType<StatesManager>();
    }

    void Update()
    {
        float heightLookup = 100;
        
        if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.terraform)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            if (transform.position.y > lastRunningPosition.y) transform.position = new Vector2(lastRunningPosition.x, lastRunningPosition.y);
            int layer = LayerMask.GetMask("Terrain");
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + heightLookup), Vector2.down, heightLookup, layer);
            if (hit.collider != null) if (hit.point.y > transform.position.y) transform.position = new Vector2(transform.position.x, hit.point.y+transform.localScale.y/2);
        }

        if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.running)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(7.0f, 0));
            transform.position = new Vector2(((transform.position.x+100)%200)-100, transform.position.y);
            lastRunningPosition = new Vector2(transform.position.x, transform.position.y);
        }

    }

}
