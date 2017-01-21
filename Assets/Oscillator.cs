using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class Oscillator : MonoBehaviour
{

    [Range(-5.0f, 5.0f)]
    public float[] surfaceHeights;
    public OneOsc[] osc = new OneOsc[0];
    OneOsc[] prevOsc = new OneOsc[0];
    public AudioSource sfxModel;
    
    void Start()
    {

    }

    void Update()
    {
        for (int j = 0; j < surfaceHeights.Length; j++)
        {
            surfaceHeights[j] = 0;
            for (int i = 0; i < osc.Length; i++)
            {
                surfaceHeights[j] += osc[i].getValueAt((float)j * (Mathf.PI * 2) / (float)surfaceHeights.Length);
            }
        }
        for (int i = 0; i < osc.Length; i++) osc[i].parent = this;
        for (int i = 0; i < osc.Length; i++) osc[i].Update();
        for (int i= osc.Length ; i<prevOsc.Length ; i++) prevOsc[i].extinct();
        prevOsc = new OneOsc[osc.Length];
        for (int i = 0; i < osc.Length; i++) prevOsc[i] = osc[i];
    }

}

[System.Serializable]
public class OneOsc
{
    
    public float frequency = 1;
    public float amplitude = 1;
    public float phase = 1;
    public float transport = 0;
    public WaveShape shape = WaveShape.sine;
    WaveShape prevShape = WaveShape.sine;

    AudioSource previewSfx;

    public Oscillator parent;
    
    public void Update()
    {
        if (previewSfx==null)
        {
            previewSfx = Object.Instantiate(parent.sfxModel);
        }
        if (prevShape!=shape) { 
            previewSfx.GetComponent<AudioSource>().clip = previewSfx.GetComponent<OscPreview>().loops[(int)shape];
            previewSfx.GetComponent<AudioSource>().Play();
            prevShape = shape;
        }
        previewSfx.GetComponent<AudioSource>().pitch = frequency;
        previewSfx.GetComponent<AudioSource>().volume = amplitude;
    }

    public void extinct()
    {
        Object.Destroy(previewSfx.gameObject);
    }

    public float getValueAt(float x) {
        float phasor = (x * frequency + phase) % (Mathf.PI*2);

        phasor += transport * (Time.time/* % (1.0f / frequency)*/);

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
        if (shape == WaveShape.noise)
        {
            return (Mathf.PerlinNoise(phasor,0)-0.5f)*amplitude;
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
