using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedFrames : MonoBehaviour {

    public Sprite[] frames = new Sprite[3];
    public float animSpeed = 1;
    float cTime = 0;

    public bool hideInTerraform = true;

    [HideInInspector]
    public StatesManager statesManager;

    void Start () {
        statesManager = FindObjectOfType<StatesManager>();
    }
	
	void Update () {
        cTime += Time.deltaTime;
        GetComponent<SpriteRenderer>().sprite = frames[(Mathf.FloorToInt(cTime*animSpeed)%frames.Length)];
        if (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.running)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = !hideInTerraform;
        }
    }
}
