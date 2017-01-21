using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorController : MonoBehaviour {

    public Oscillator oscillator;

    public float minFrequency = 1.0f;
    public float maxFrequency = 100.0f;

    public float minAmplitude = 1.0f;
    public float maxAmplitude = 100.0f;

    public float phaseChangeFactor = 1.0f;

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

        if (!m_statesManager.input.IsAmplitudeLocked())
            currentOscillator.amplitude = Mathf.Lerp(minAmplitude, maxAmplitude, m_statesManager.input.GetAmplitude());

        if (!m_statesManager.input.IsFrequencyLocked())
            currentOscillator.frequency = Mathf.Lerp(minFrequency, maxFrequency, m_statesManager.input.GetFrequency());

        if (m_statesManager.input.GetSineShapeChange()) currentOscillator.shape = OneOsc.WaveShape.sine;
        if (m_statesManager.input.GetSquareShapeChange()) currentOscillator.shape = OneOsc.WaveShape.square;
        if (m_statesManager.input.GetSawShapeChange()) currentOscillator.shape = OneOsc.WaveShape.saw;
        if (m_statesManager.input.GetNoiseShapeChange()) currentOscillator.shape = OneOsc.WaveShape.noise;

        currentOscillator.phase += m_statesManager.input.GetPhase() * phaseChangeFactor;

        if (m_statesManager.input.NextWave())
        {
            m_currentWave = (m_currentWave + 1) % oscillator.osc.Length;
        }
        if (m_statesManager.input.PreviousWave())
        {
            m_currentWave = (m_currentWave - 1 + oscillator.osc.Length) % oscillator.osc.Length;
        }
    }

    int m_currentWave = 0;
    StatesManager m_statesManager;
}
