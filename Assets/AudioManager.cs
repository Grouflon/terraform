using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [HideInInspector]
    public StatesManager statesManager;

    public AudioSource runningMusic;

    void Start () {
        statesManager = FindObjectOfType<StatesManager>();
    }

    void Update () {
        runningMusic.volume = statesManager.GetComponent<StatesManager>().state==StatesManager.GameStates.running?1:0;

    }
}
