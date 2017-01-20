using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    public float[] surfaceHeights;

    public float frequency = 1;
    public float amplitude = 1;
    public float phase = 1;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i=0 ; i<surfaceHeights.Length ; i++)
        {
            surfaceHeights[i] = Mathf.Sin(i*frequency+phase)*amplitude;
        }
	}
    
}
