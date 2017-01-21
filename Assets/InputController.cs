using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public abstract bool PreviousWave();
    public abstract bool NextWave();
    public abstract float GetFrequencyChange();
    public abstract float GetAmplitudeChange();
    public abstract float GetPhaseChange();

    public abstract bool GetSineShapeMode();
    public abstract bool GetSquareShapeMode();
    public abstract bool GetSawShapeMode();
    public abstract bool GetNoiseShapeMode();

    public bool GetAnyShapeMode()
    {
        return GetSineShapeMode() || GetSquareShapeMode() || GetSawShapeMode() || GetNoiseShapeMode();
    }
}
