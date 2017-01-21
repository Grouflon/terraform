using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour {

    [Range(-5.0f, 5.0f)]
    public float[] surfaceHeights;
    public OneOsc[] osc = new OneOsc[1];
    
    void Start () {
		
	}
	
	void Update () {
        for (int j=0 ; j<surfaceHeights.Length ; j++)
        {
            surfaceHeights[j] = 0;
            for (int i = 0; i < osc.Length; i++)
            {
                surfaceHeights[j] += osc[i].getValueAt((float)j * (Mathf.PI*2) / (float)surfaceHeights.Length);
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
    
    public float getValueAt(float x) {
        float phasor = (x * frequency + phase) % (Mathf.PI*2);
        if (shape == WaveShape.sine)
        {
            return Mathf.Sin(phasor) * amplitude;
        }
        if (shape == WaveShape.triangle)
        {
            float value = phasor;
            if (phasor > Mathf.PI * 1 / 2) value -= (phasor - (Mathf.PI / 2)) * 2.0f;
            if (phasor > Mathf.PI * 3 / 2) value += (phasor - (Mathf.PI * 3 / 2)) * 2.0f;
            return value * amplitude;
        }
        if (shape == WaveShape.square)
        {
            if (phasor < Mathf.PI) return amplitude;
            return -amplitude;
        }
        if (shape == WaveShape.saw)
        {
            return ((phasor/(Mathf.PI*2))-0.5f) * -amplitude;
        }
        return 0;
    }

    public enum WaveShape {
        sine,
        triangle,
        square,
        saw,
        noise
    }
    
}
