using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : InputController {

    public float amplitudeSensitivity = 0.01f;
    public float frequencySensitivity = 0.01f;

    float m_amplitude = 0.0f;
    float m_frequency = 0.0f;

    void Update()
    {
        if (!IsAmplitudeLocked())
        {
            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
            {
                m_amplitude = Mathf.Clamp01(m_amplitude + amplitudeSensitivity);
            }
            if (Input.GetKey(KeyCode.S))
            {
                m_amplitude = Mathf.Clamp01(m_amplitude - amplitudeSensitivity);
            }
        }

        if (!IsFrequencyLocked())
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
            {
                m_frequency = Mathf.Clamp01(m_frequency - frequencySensitivity);
            }
            if (Input.GetKey(KeyCode.D))
            {
                m_frequency = Mathf.Clamp01(m_frequency + frequencySensitivity);
            }
        }
    }

    public override float GetAmplitude()
    {
        return m_amplitude;
    }

    public override float GetFrequency()
    {
        return m_frequency;
    }

    public override float GetPhase()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            result -= 1.0f;
        if (Input.GetKey(KeyCode.RightArrow))
            result += 1.0f;
        return result;
    }

    public override bool GetSineShapeChange()
    {
        return Input.GetKeyDown(KeyCode.Keypad1);
    }

    public override bool GetSquareShapeChange()
    {
        return Input.GetKeyDown(KeyCode.Keypad2);
    }

    public override bool GetSawShapeChange()
    {
        return Input.GetKeyDown(KeyCode.Keypad3);
    }

    public override bool GetNoiseShapeChange()
    {
        return Input.GetKeyDown(KeyCode.Keypad4);
    }

    public override bool PreviousWave()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public override bool NextWave()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }

    public override bool IsFrequencyLocked()
    {
        return !Input.GetKey(KeyCode.Keypad1)
            && !Input.GetKey(KeyCode.Keypad2)
            && !Input.GetKey(KeyCode.Keypad3)
            && !Input.GetKey(KeyCode.Keypad4);
    }

    public override bool IsAmplitudeLocked()
    {
        return !Input.GetKey(KeyCode.Keypad1)
            && !Input.GetKey(KeyCode.Keypad2)
            && !Input.GetKey(KeyCode.Keypad3)
            && !Input.GetKey(KeyCode.Keypad4);
    }

    public override bool ToggleGameState()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
