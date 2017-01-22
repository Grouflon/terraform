using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class Oscillator : MonoBehaviour
{

    [Range(-5.0f, 5.0f)]
    public float[] surfaceHeights;
    public float[] currentSurfaceHeights;
    public OneOsc[] osc = new OneOsc[0];
    OneOsc[] prevOsc = new OneOsc[0];
    public AudioSource sfxModel;
    public float middlePoint = Mathf.PI;

    [HideInInspector]
    public StatesManager statesManager;
    [HideInInspector]
    public OscillatorController oscilatorController;

    void Start()
    {
        statesManager = FindObjectOfType<StatesManager>();
        oscilatorController = FindObjectOfType<OscillatorController>();
    }

    void Update()
    {
        for (int i = 0; i < osc.Length; i++) osc[i].parent = this;
        for (int i = 0; i < osc.Length; i++) osc[i].Update();
        currentSurfaceHeights = new float[surfaceHeights.Length];
        for (int j = 0; j < surfaceHeights.Length; j++)
        {
            surfaceHeights[j] = 0;
            for (int i = 0; i < osc.Length; i++) surfaceHeights[j] += osc[i].getValueAt((float)j * (Mathf.PI * 2) / surfaceHeights.Length);
            currentSurfaceHeights[j] = osc[oscilatorController.m_currentWave].getValueAt((float)j * (Mathf.PI * 2) / surfaceHeights.Length);
        }
        for (int i = 0; i < prevOsc.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < osc.Length; j++) if (osc[j] == prevOsc[i]) found = true;
            if (!found) prevOsc[i].extinct();
        }
        prevOsc = new OneOsc[osc.Length];
        for (int i = 0; i < osc.Length; i++) prevOsc[i] = osc[i];
    }

    public void resetOsc()
    {
        
    }

}

[System.Serializable]
public class OneOsc
{
    public bool active = false;
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
        if (!prevShape.Equals(shape)) {
            previewSfx.GetComponent<AudioSource>().clip = previewSfx.GetComponent<OscPreview>().loops[(int)shape];
            previewSfx.GetComponent<AudioSource>().Play();
            prevShape = shape;
        }
        previewSfx.GetComponent<AudioSource>().pitch = frequency*0.2f; 
        previewSfx.GetComponent<AudioSource>().volume = (parent.statesManager.state == StatesManager.GameStates.terraform && active) ? Mathf.Abs(amplitude) : 0.0f;
    }

    public void extinct()
    {
        Object.Destroy(previewSfx.gameObject);
    }

    public float getValueAt(float x) {
        if (!active)
            return 0.0f;

        float phasor = ((x - parent.middlePoint) * frequency + phase);
        float linearPhasor = ((x - parent.middlePoint) * frequency + phase);
        while (phasor<0||phasor>=Mathf.PI*2) phasor = (phasor + Mathf.PI * 2) % (Mathf.PI*2);

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
            if (phasor < Mathf.PI) return amplitude*0.5f;
            return -amplitude;
        }
        if (shape == WaveShape.saw)
        {
            return ((phasor/(Mathf.PI*2))-0.5f) * -amplitude*2.0f;
        }
        if (shape == WaveShape.noise)
        {
            return (Mathf.PerlinNoise(linearPhasor/2.0f,0)-0.5f)*amplitude*2.75f;
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
