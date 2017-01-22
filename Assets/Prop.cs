using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour {

    public Sprite[] sprites = new Sprite[7];

    [HideInInspector]
    public StatesManager statesManager;

    void Start()
    {
        statesManager = FindObjectOfType<StatesManager>();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 7)];
        transform.position = new Vector2(-100+Random.value*200,200);
        float scale = Random.value*2.0f + 1.0f;
        transform.localScale = new Vector2(scale,scale);
    }
	
	
    void Update () {
        transform.position = new Vector2(transform.position.x, 200);
        int layer = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 500, layer);
        if (hit.collider != null)
        {
            print(hit.ToString());
            transform.position = hit.point;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);
        GetComponent<SpriteRenderer>().enabled = (statesManager.state == StatesManager.GameStates.running);
    }
}
