using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadInputController : InputController
{
    public override float GetAmplitude()
    {
        //Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //return input.magnitude;

        return (1.0f + Input.GetAxis("Vertical")) * 0.5f;
    }

    public override float GetFrequency()
    {
        //Vector2 input = new Vector2(Input.GetAxis("RightHorizontal"), Input.GetAxis("RightVertical"));
        //return input.magnitude;

        return (1.0f + Input.GetAxis("Horizontal")) * 0.5f;
    }

    public override float GetPhase()
    {
        return Input.GetAxis("DPadHorizontal");
    }

    public override bool GetSineShapeChange()
    {
        return Input.GetButton("A");
    }

    public override bool GetSquareShapeChange()
    {
        return Input.GetButton("B");
    }

    public override bool GetSawShapeChange()
    {
        return Input.GetButton("X");
    }

    public override bool GetNoiseShapeChange()
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

    public override bool IsFrequencyLocked()
    {
        return !Input.GetButton("A")
            && !Input.GetButton("B")
            && !Input.GetButton("X")
            && !Input.GetButton("Y");
    }

    public override bool IsAmplitudeLocked()
    {
        return !Input.GetButton("A")
            && !Input.GetButton("B")
            && !Input.GetButton("X")
            && !Input.GetButton("Y");
    }

    public override bool ToggleGameState()
    {
        return Input.GetButtonDown("Start");
    }

    public override StatesManager.GameStates currentGameState()
    {
        return Input.GetButton("A")
            || Input.GetButton("B")
            || Input.GetButton("X")
            || Input.GetButton("Y") ?
            StatesManager.GameStates.terraform : StatesManager.GameStates.running;
    }

}
