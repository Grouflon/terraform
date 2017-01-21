using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : InputController {

    public override float GetAmplitudeChange()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
            result -= 1.0f;
        if (Input.GetKey(KeyCode.D))
            result += 1.0f;

        return result;
    }

    public override float GetFrequencyChange()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
            result += 1.0f;
        if (Input.GetKey(KeyCode.S))
            result += 1.0f;

        return result;
    }

    public override float GetPhaseChange()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow))
            result -= 1.0f;
        if (Input.GetKey(KeyCode.RightArrow))
            result += 1.0f;

        return result;
    }

    public override bool GetSineShapeMode()
    {
        return Input.GetKey(KeyCode.Keypad1);
    }

    public override bool GetSquareShapeMode()
    {
        return Input.GetKey(KeyCode.Keypad2);
    }

    public override bool GetSawShapeMode()
    {
        return Input.GetKey(KeyCode.Keypad3);
    }

    public override bool GetNoiseShapeMode()
    {
        return Input.GetKey(KeyCode.Keypad4);
    }

    public override bool PreviousWave()
    {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public override bool NextWave()
    {
        return Input.GetKeyDown(KeyCode.DownArrow);
    }
}
