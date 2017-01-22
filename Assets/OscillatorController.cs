using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorController : MonoBehaviour {

    public GameObject terrainPrefab;
    public Oscillator oscillator;

    public float minFrequency = 1.0f;
    public float maxFrequency = 100.0f;

    public float minAmplitude = -100.0f;
    public float maxAmplitude = 100.0f;

    public float amplitudeSensitivity = 0.01f;
    public float frequencySensitivity = 0.01f;

    public float phaseSensitivity = 1.0f;

    public Material idleWaveMaterial;
    public Material activeWaveMaterial;

    void Start()
    {
        m_statesManager = FindObjectOfType<StatesManager>();

        oscillator.osc[0].active = true;
        for (int i = 1; i < oscillator.osc.Length; ++i)
        {
            oscillator.osc[i].active = false;
        }

        m_previewRenderers = new TerrainRenderer[oscillator.osc.Length];
        RegenerateWavePreviews();
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
                m_currentWave = Mathf.Clamp(m_currentWave + 1, 0, oscillator.osc.Length - 1);
                RegenerateWavePreviews();
            }
            if (m_statesManager.input.PreviousWave())
            {
                m_currentWave = Mathf.Clamp(m_currentWave - 1, 0, oscillator.osc.Length - 1);
                RegenerateWavePreviews();
            }

            for (int i = 0; i < oscillator.osc.Length; ++i)
            {
                oscillator.osc[i].active = i <= m_currentWave;
            }
        }
    }

    void RegenerateWavePreviews()
    {
        for (int i = 0; i < m_previewRenderers.Length; ++i)
        {
            if (m_previewRenderers[i] != null)
            {
                Destroy(m_previewRenderers[i].gameObject);
                m_previewRenderers[i] = null;
            }
        }

        for (int i = 0; i < m_previewRenderers.Length; ++i)
        {
            if (i > m_currentWave)
                break;

            float start = 0.75f;
            float end = 0.97f;
            Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, start + i * ((end - start) / m_previewRenderers.Length), 0.0f));
            position.z = 0.0f;

            GameObject obj = Instantiate(terrainPrefab, position, Quaternion.identity);
            m_previewRenderers[i] = obj.GetComponent<TerrainRenderer>();

            m_previewRenderers[i].targetWave = i;
            m_previewRenderers[i].amplifier = 0.2f;
            m_previewRenderers[i].GetComponent<EdgeCollider2D>().enabled = false;

            if (i == m_currentWave)
            {
                m_previewRenderers[i].width = 0.2f;
                Color color = Color.white;
                color.a = 0.5f;
                m_previewRenderers[i].material = activeWaveMaterial;
            }
            else
            {
                m_previewRenderers[i].width = 0.1f;
                Color color = Color.green;
                color.a = 0.2f;
                m_previewRenderers[i].material = idleWaveMaterial;
            }
        }
    }

    TerrainRenderer[] m_previewRenderers;

    public int m_currentWave = 0;
    StatesManager m_statesManager;
}
