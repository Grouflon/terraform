using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour {

    public Sprite[] sprites = new Sprite[7];

    [HideInInspector]
    public StatesManager statesManager;

    float swingFr = 0;
    float swingAm = 0;
    public float scaleRange = 0.5f;

    void Start()
    {
        float screenStart = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.0f, 0.0f)).x - 1.0f;
        float screenEnd = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.0f, 0.0f)).x + 1.0f;

        swingFr = Random.value + 1.0f;
        swingAm = Random.value * 30.0f;

        statesManager = FindObjectOfType<StatesManager>();
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 7)];
        transform.position = new Vector3(screenStart + Random.value* (screenEnd - screenStart), screenEnd, 1.5f);
        transform.localScale = Random.value*2.0f * scaleRange * transform.localScale;
    }
	
	
    void Update () {
        /*transform.position = new Vector2(transform.position.x, 200);
        transform.rotation = Quaternion.Euler(0,0,Mathf.Sin(Time.time * swingFr / 5.0f) * swingAm);
        int layer = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 500, layer);
        if (hit.collider != null)
        {
            transform.position = hit.point;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 1.5f);*/
        GetComponent<SpriteRenderer>().enabled = (statesManager.state == StatesManager.GameStates.running);
    }
}
