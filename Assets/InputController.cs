using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    /*public abstract bool PreviousWave();
    public abstract bool NextWave();*/
    public abstract float GetFrequencyChange();
    public abstract float GetAmplitudeChange();
    public abstract float GetPhaseChange();

    public abstract bool GetWave0();
    public abstract bool GetWave1();
    public abstract bool GetWave2();
    public abstract bool GetWave3();

    public abstract bool NextShape();
    public abstract bool PreviousShape();

    /*public abstract bool GetSineShapeMode();
    public abstract bool GetSquareShapeMode();
    public abstract bool GetSawShapeMode();
    public abstract bool GetNoiseShapeMode();*/

    public bool IsAnyWaveOn()
    {
        return GetWave0() || GetWave1() || GetWave2() || GetWave3();
    }
}
