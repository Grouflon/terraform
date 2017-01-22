using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputController : InputController {

    public override float GetAmplitudeChange()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
            result += 1.0f;
        if (Input.GetKey(KeyCode.S))
            result -= 1.0f;

        return result;
    }
    
    public override float GetFrequencyChange()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
            result -= 1.0f;
        if (Input.GetKey(KeyCode.D))
            result += 1.0f;

        return result;
    }

    public override float GetPhaseChange()
    {
        float result = 0.0f;
        if (Input.GetKey(KeyCode.M))
            result -= 1.0f;
        if (Input.GetKey(KeyCode.K))
            result += 1.0f;

        return result;
    }

    public override bool GetWave0()
    {
        return Input.GetKey(KeyCode.Keypad1);
    }

    public override bool GetWave1()
    {
        return Input.GetKey(KeyCode.Keypad2);
    }

    public override bool GetWave2()
    {
        return Input.GetKey(KeyCode.Keypad3);
    }

    public override bool GetWave3()
    {
        return Input.GetKey(KeyCode.Keypad4);
    }

    public override bool PreviousShape()
    {
        return Input.GetKeyDown(KeyCode.O);
    }

    public override bool NextShape()
    {
        return Input.GetKeyDown(KeyCode.L);
    }
}
