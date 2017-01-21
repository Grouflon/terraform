﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour {

    public GameStates state = GameStates.running;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            state = GameStates.terraform;
        }
        else
        {
            state = GameStates.running;
        }
        if (state == GameStates.terraform) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public enum GameStates
    {
        running,
        terraform
    }

}
