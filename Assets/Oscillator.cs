using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    public float[] surfaceHeights;
    public OneOsc[] osc = new OneOsc[1];
    
    void Start () {
		
	}
	
	void Update () {
        for (int i=0;i<osc.Length;i++) {
            for (int j=0 ; j<surfaceHeights.Length ; j++)
            {
                surfaceHeights[i] = osc[i].getValueAt(i); 
            }
	    }
    }

}

[System.Serializable]
public class OneOsc
{
    
    public float frequency = 1;
    public float amplitude = 1;
    public float phase = 1;
    public WaveShape shape = WaveShape.sine;
    
    public float getValueAt(int x) {
        return Mathf.Sin(x * frequency + phase) * amplitude;
    }

    public enum WaveShape {
        sine,
        triangle,
        square,
        noise
    }
    
}
