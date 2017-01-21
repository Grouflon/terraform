using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadInputController : InputController
{
    public override float GetAmplitudeChange()
    {
        return Input.GetAxis("Vertical");
    }

    public override float GetFrequencyChange()
    {
        return Input.GetAxis("Horizontal");
    }

    public override float GetPhaseChange()
    {
        return Input.GetAxis("DPadHorizontal");
    }

    public override bool GetSineShapeMode()
    {
        return Input.GetButton("A");
    }

    public override bool GetSquareShapeMode()
    {
        return Input.GetButton("B");
    }

    public override bool GetSawShapeMode()
    {
        return Input.GetButton("X");
    }

    public override bool GetNoiseShapeMode()
    {
        return Input.GetButton("Y");
    }

    public override bool PreviousWave()
    {
        return Input.GetButtonDown("LeftBumper");
    }

    public override bool NextWave()
    {
        return Input.GetButtonDown("RightBumper");
    }

}
