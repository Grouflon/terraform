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
        return -Input.GetAxis("DPadHorizontal");
    }

    public override bool GetWave0()
    {
        return Input.GetButton("A");
    }

    public override bool GetWave1()
    {
        return Input.GetButton("B");
    }

    public override bool GetWave2()
    {
        return Input.GetButton("X");
    }

    public override bool GetWave3()
    {
        return Input.GetButton("Y");
    }

    public override bool PreviousShape()
    {
        return Input.GetButtonDown("LeftBumper");
    }

    public override bool NextShape()
    {
        return Input.GetButtonDown("RightBumper");
    }

}
