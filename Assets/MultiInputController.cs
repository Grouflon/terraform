using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiInputController : InputController {

    public InputController[] inputs;

    public override float GetAmplitudeChange()
    {
        float result = 0.0f;

        foreach(InputController input in inputs)
        {
            if (Mathf.Abs(input.GetAmplitudeChange()) > Mathf.Abs(result))
                result = input.GetAmplitudeChange();
        }

        return result;
    }

    public override float GetFrequencyChange()
    {
        float result = 0.0f;

        foreach (InputController input in inputs)
        {
            if (Mathf.Abs(input.GetFrequencyChange()) > Mathf.Abs(result))
                result = input.GetFrequencyChange();
        }

        return result;
    }

    public override float GetPhaseChange()
    {
        float result = 0.0f;

        foreach (InputController input in inputs)
        {
            if (Mathf.Abs(input.GetPhaseChange()) > Mathf.Abs(result))
                result = input.GetPhaseChange();
        }

        return result;
    }

    public override bool GetSineShapeMode()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetSineShapeMode();
        }

        return result;
    }

    public override bool GetSquareShapeMode()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetSquareShapeMode();
        }

        return result;
    }

    public override bool GetSawShapeMode()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetSawShapeMode();
        }

        return result;
    }

    public override bool GetNoiseShapeMode()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetNoiseShapeMode();
        }

        return result;
    }

    public override bool PreviousWave()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.PreviousWave();
        }

        return result;
    }

    public override bool NextWave()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.NextWave();
        }

        return result;
    }
}
