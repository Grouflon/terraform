using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedFrames : MonoBehaviour {

    public Sprite[] frames = new Sprite[3];
    public float animSpeed = 1;
    float cTime = 0;
    public bool pingpong = false;
    bool forward = true;

    [HideInInspector]
    public StatesManager statesManager;

    void Start () {
        statesManager = FindObjectOfType<StatesManager>();
    }
	
	void Update () {
        if (!pingpong) cTime = (cTime + Time.deltaTime * animSpeed) % frames.Length;
        if (pingpong)
        {
            if (cTime >= frames.Length-1) forward = false;
            if (cTime <= 0) forward = true;
            cTime += Time.deltaTime * animSpeed * (forward?1:-1);
            cTime = Mathf.Max(Mathf.Min(cTime, frames.Length - 1), 0);
        }

        GetComponent<SpriteRenderer>().sprite = frames[Mathf.FloorToInt(cTime)];
        GetComponent<SpriteRenderer>().enabled = (statesManager.GetComponent<StatesManager>().state == StatesManager.GameStates.running);
    }
}
