using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedFrames : MonoBehaviour {

    public Sprite[] frames = new Sprite[3];
    public float animSpeed = 1;
    int currentFrame = 0;
    float cTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cTime += Time.deltaTime;
        GetComponent<SpriteRenderer>().sprite = frames[(Mathf.FloorToInt(cTime*animSpeed)%frames.Length)];
    }
}
