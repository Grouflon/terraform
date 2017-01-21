using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputController : MonoBehaviour
{
    public abstract bool ToggleGameState();

    public abstract bool PreviousWave();
    public abstract bool NextWave();
    public abstract bool IsFrequencyLocked();
    public abstract bool IsAmplitudeLocked();
    public abstract float GetFrequency();
    public abstract float GetAmplitude();
    public abstract float GetPhase();
    public abstract bool GetSineShapeChange();
    public abstract bool GetSquareShapeChange();
    public abstract bool GetSawShapeChange();
    public abstract bool GetNoiseShapeChange();
}
