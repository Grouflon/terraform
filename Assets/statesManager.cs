using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesManager : MonoBehaviour
{
    public InputController input;
    public OscillatorController oscController;

    public GameStates state = GameStates.running;

	void Start () {
		
	}
	
	void Update () {
        if (input.ToggleGameState())
        {
            if (state == GameStates.terraform)
                state = GameStates.running;
            else
                state = GameStates.terraform;
        }

        if (state == GameStates.terraform)
        {
            Time.timeScale = 0;
            oscController.enabled = true;
        }
        else
        {
            Time.timeScale = 1;
            oscController.enabled = false;
        }
    }

    public enum GameStates
    {
        running,
        terraform
    }

}
