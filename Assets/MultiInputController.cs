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

    public override bool GetWave0()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetWave0();
        }

        return result;
    }

    public override bool GetWave1()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetWave1();
        }

        return result;
    }

    public override bool GetWave2()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetWave2();
        }

        return result;
    }

    public override bool GetWave3()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.GetWave3();
        }

        return result;
    }

    public override bool PreviousShape()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.PreviousShape();
        }

        return result;
    }

    public override bool NextShape()
    {
        bool result = false;

        foreach (InputController input in inputs)
        {
            result = result || input.NextShape();
        }

        return result;
    }
}
