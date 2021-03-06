﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [HideInInspector]
    public StatesManager statesManager;

    public AudioSource runningMusic;
    public AudioSource loot;
    public AudioSource die;
    public AudioSource win;
    public AudioSource switchOnSfx;
    public AudioSource switchOffSfx;
    public AudioSource bonusPopSfx;
    public AudioSource charHitSfx;
    public AudioSource charJumpSfx;

    void Start () {
        statesManager = FindObjectOfType<StatesManager>();
    }

    void Update () {
        runningMusic.volume = statesManager.GetComponent<StatesManager>().state==StatesManager.GameStates.running?1:0;
    }

    public void playLoot()
    {
        loot.Play();
    }

    public void playDie()
    {
        die.Play();
    }

    public void playWin()
    {
        // win.Play();
    }

    public void switchOn()
    {
        switchOnSfx.Play();
    }

    public void switchOff()
    {
        switchOffSfx.Play();
    }

    public void bonusPop()
    {
        bonusPopSfx.Play();
    }

    public void charHit()
    {
        charHitSfx.GetComponent<audioPool>().play();
    }

    public void charJump()
    {
        charJumpSfx.GetComponent<audioPool>().play();
    }

}
