﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public InputController input;

    [HideInInspector]
    public GameStates state = GameStates.running;
    GameStates previousState = GameStates.running;

    [HideInInspector]
    AudioManager audioManager;

    public float terraformingTimeScale = 0.1f;
    public float timeScaleLerpRatio = 0.01f;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (previousState != state)
        {
            if (state == GameStates.terraform) audioManager.switchOn();
            if (state == GameStates.running) audioManager.switchOff();
            previousState = state;
        }
        if (input.IsAnyWaveOn())
        {
            state = GameStates.terraform;
        }
        else
        {
            state = GameStates.running;
        }


        if (state == GameStates.terraform)
        {
            // Time.timeScale = 0;
            //oscController.enabled = true;

            Camera.main.backgroundColor = Color.black;
            Camera.main.GetComponent<PostRenderer>().enabled = true;

            Time.timeScale = Mathf.Lerp(Time.timeScale, terraformingTimeScale, timeScaleLerpRatio);
        }
        else
        {
            // Time.timeScale = 1;
            //oscController.enabled = false;

            Camera.main.backgroundColor = new Color(146.0f / 255.0f, 174.0f / 255.0f, 1.0f);
            Camera.main.GetComponent<PostRenderer>().enabled = false;

            Time.timeScale = Mathf.Lerp(Time.timeScale, 1.0f, timeScaleLerpRatio);
        }
    }

    public enum GameStates
    {
        running,
        terraform
    }
}
