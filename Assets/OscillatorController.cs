using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorController : MonoBehaviour {

    public Oscillator oscillator;

    public float minFrequency = 1.0f;
    public float maxFrequency = 100.0f;

    public float minAmplitude = -100.0f;
    public float maxAmplitude = 100.0f;

    public float amplitudeSensitivity = 0.01f;
    public float frequencySensitivity = 0.01f;

    public float phaseSensitivity = 1.0f;

    void Start()
    {
        m_statesManager = FindObjectOfType<StatesManager>();
    }

    void Update ()
    {
        if (oscillator == null)
            return;

        if (oscillator.osc.Length == 0)
            return;

        if (m_currentWave >= oscillator.osc.Length)
            m_currentWave = oscillator.osc.Length - 1;

        OneOsc currentOscillator = oscillator.osc[m_currentWave];

        if (m_statesManager.input.GetAnyShapeMode())
        {
            currentOscillator.amplitude = Mathf.Clamp(currentOscillator.amplitude + m_statesManager.input.GetAmplitudeChange() * amplitudeSensitivity, minAmplitude, maxAmplitude);
            currentOscillator.frequency = Mathf.Clamp(currentOscillator.frequency + m_statesManager.input.GetFrequencyChange() * frequencySensitivity, minFrequency, maxFrequency);

            if (m_statesManager.input.GetSineShapeMode()) currentOscillator.shape = OneOsc.WaveShape.sine;
            if (m_statesManager.input.GetSquareShapeMode()) currentOscillator.shape = OneOsc.WaveShape.square;
            if (m_statesManager.input.GetSawShapeMode()) currentOscillator.shape = OneOsc.WaveShape.saw;
            if (m_statesManager.input.GetNoiseShapeMode()) currentOscillator.shape = OneOsc.WaveShape.noise;

            currentOscillator.phase += m_statesManager.input.GetPhaseChange() * phaseSensitivity;

            if (m_statesManager.input.NextWave())
            {
                m_currentWave = (m_currentWave + 1) % oscillator.osc.Length;
            }
            if (m_statesManager.input.PreviousWave())
            {
                m_currentWave = (m_currentWave - 1 + oscillator.osc.Length) % oscillator.osc.Length;
            }
        }
    }

    int m_currentWave = 0;
    StatesManager m_statesManager;
}
