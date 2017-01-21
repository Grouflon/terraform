using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorController : MonoBehaviour {

    public InputController input;
    public Oscillator oscillator;

    public float minFrequency = 1.0f;
    public float maxFrequency = 100.0f;

    public float minAmplitude = 1.0f;
    public float maxAmplitude = 100.0f;

    public float phaseChangeFactor = 1.0f;

    void Update ()
    {
        if (oscillator == null)
            return;

        if (oscillator.osc.Length == 0)
            return;

        if (m_currentWave >= oscillator.osc.Length)
            m_currentWave = oscillator.osc.Length - 1;

        OneOsc currentOscillator = oscillator.osc[m_currentWave];

        if (!input.IsAmplitudeLocked())
            currentOscillator.amplitude = Mathf.Lerp(minAmplitude, maxAmplitude, input.GetAmplitude());

        if (!input.IsFrequencyLocked())
            currentOscillator.frequency = Mathf.Lerp(minFrequency, maxFrequency, input.GetFrequency());

        if (input.GetSineShapeChange()) currentOscillator.shape = OneOsc.WaveShape.sine;
        if (input.GetSquareShapeChange()) currentOscillator.shape = OneOsc.WaveShape.square;
        if (input.GetSawShapeChange()) currentOscillator.shape = OneOsc.WaveShape.saw;
        if (input.GetNoiseShapeChange()) currentOscillator.shape = OneOsc.WaveShape.noise;

        currentOscillator.phase += input.GetPhase() * phaseChangeFactor;

        if (input.NextWave())
        {
            m_currentWave = (m_currentWave + 1) % oscillator.osc.Length;
        }
        if (input.PreviousWave())
        {
            m_currentWave = (m_currentWave - 1 + oscillator.osc.Length) % oscillator.osc.Length;
        }
    }

    int m_currentWave = 0;
}
